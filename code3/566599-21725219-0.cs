    using System;
    using System.Windows.Forms;
    using System.IO;
    
    using System.Security;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    
    using iTextSharp.text.pdf;
    using iTextSharp.text.pdf.security;
    
    
    
    namespace SignPdf
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private  SecureString GetSecurePin(string PinCode)
            {
                SecureString pwd = new SecureString();
                foreach (var c in PinCode.ToCharArray()) pwd.AppendChar(c);
                return pwd;
            }
            private  void button1_Click(object sender, EventArgs e)
            {
                //Sign from SmartCard
                //note : ProviderName and KeyContainerName can be found with the dos command : CertUtil -ScInfo
                string ProviderName = textBox2.Text;
                string KeyContainerName = textBox3.Text;
                string PinCode = textBox4.Text;
                if (PinCode != "")
                {
                    //if pin code is set then no windows form will popup to ask it
                    SecureString pwd = GetSecurePin(PinCode);
                    CspParameters csp = new CspParameters(1,
                                                            ProviderName,
                                                            KeyContainerName,
                                                            new System.Security.AccessControl.CryptoKeySecurity(),
                                                            pwd);
                    try
                    {
                        RSACryptoServiceProvider rsaCsp = new RSACryptoServiceProvider(csp);
                        // the pin code will be cached for next access to the smart card
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Crypto error: " + ex.Message);
                        return;
                    }
                }           
                X509Store store = new X509Store(StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2 cert = null;
                if ((ProviderName == "") || (KeyContainerName == ""))
                {
                    MessageBox.Show("You must set Provider Name and Key Container Name");
                    return;
                }
                foreach (X509Certificate2 cert2 in store.Certificates)
                {
                    if (cert2.HasPrivateKey)
                    {
                        RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)cert2.PrivateKey;
                        if (rsa == null) continue; // not smart card cert again
                        if (rsa.CspKeyContainerInfo.HardwareDevice) // sure - smartcard
                        {
                            if ((rsa.CspKeyContainerInfo.KeyContainerName == KeyContainerName) && (rsa.CspKeyContainerInfo.ProviderName == ProviderName))
                            {
                                //we find it
                                cert = cert2;
                                break;
                            }
                        }
                    }
                }
                if (cert == null)
                {
                    MessageBox.Show("Certificate not found");
                    return;
                }
                SignWithThisCert(cert);
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                //Sign with certificate selection in the windows certificate store
                X509Store store = new X509Store(StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2 cert = null;
                //manually chose the certificate in the store
                X509Certificate2Collection sel = X509Certificate2UI.SelectFromCollection(store.Certificates, null, null, X509SelectionFlag.SingleSelection);
                if (sel.Count > 0)
                    cert = sel[0];
                else
                {
                    MessageBox.Show("Certificate not found");
                    return;
                }
                SignWithThisCert(cert);
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                //Sign from certificate in a pfx or a p12 file
                string PfxFileName = textBox5.Text;
                string PfxPassword = textBox6.Text;
                X509Certificate2 cert = new X509Certificate2(PfxFileName, PfxPassword);
                SignWithThisCert(cert);
            }
    
            private void SignWithThisCert(X509Certificate2 cert)
            {
                string SourcePdfFileName = textBox1.Text;
                string DestPdfFileName = textBox1.Text + "-Signed.pdf";
                Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
                Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] { cp.ReadCertificate(cert.RawData) };
                IExternalSignature externalSignature = new X509Certificate2Signature(cert, "SHA-1");
                PdfReader pdfReader = new PdfReader(SourcePdfFileName);
                FileStream signedPdf = new FileStream(DestPdfFileName, FileMode.Create);  //the output pdf file
                PdfStamper pdfStamper = PdfStamper.CreateSignature(pdfReader, signedPdf, '\0');
                PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;
                //here set signatureAppearance at your will
                signatureAppearance.Reason = "Because I can";
                signatureAppearance.Location = "My location";
                signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.DESCRIPTION;
                MakeSignature.SignDetached(signatureAppearance, externalSignature, chain, null, null, null, 0, CryptoStandard.CMS);
                //MakeSignature.SignDetached(signatureAppearance, externalSignature, chain, null, null, null, 0, CryptoStandard.CADES);
                MessageBox.Show("Done");
            }
        
        }
    
    
    }
