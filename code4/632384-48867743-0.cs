     public byte[] SignPdf(byte[] pdf)
        {
            
            using (MemoryStream output = new MemoryStream()) {
                //get certificate from path
                X509Certificate2 cert1 = new X509Certificate2(@"C:\temp\certtemp.pfx", "12345", X509KeyStorageFlags.Exportable);
                //get private key to sign pdf
                var pk = Org.BouncyCastle.Security.DotNetUtilities.GetKeyPair(cert1.PrivateKey).Private;
                // convert the type to be used at .SetCrypt(); 
                Org.BouncyCastle.X509.X509Certificate bcCert = Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate(cert1);
                // get the pdf u want to sign
                PdfReader pdfReader = new PdfReader(pdf);
                PdfStamper stamper = PdfStamper.CreateSignature(pdfReader, output, '\0');
                PdfSignatureAppearance pdfSignatureAppearance = stamper.SignatureAppearance;
                //.SetCrypt(); sign the pdf
                pdfSignatureAppearance.SetCrypto(pk, new Org.BouncyCastle.X509.X509Certificate[] { bcCert }, null, PdfSignatureAppearance.WINCER_SIGNED);
                pdfSignatureAppearance.Reason = "Este documento está assinado digitalmente pelo Estado Portugues";
                pdfSignatureAppearance.Location = " Lisboa, Portugal";
                pdfSignatureAppearance.SignDate = DateTime.Now;
                stamper.Close();
                return output.ToArray();
            }
        } 
