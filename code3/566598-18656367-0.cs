     X509Certificate2 cert = new X509Certificate2("C:\\mycert.p12");
     Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
     Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] {
     cp.ReadCertificate(cert.RawData)};
     IExternalSignature externalSignature = new X509Certificate2Signature(cert, "SHA-1");
     PdfReader pdfReader = new PdfReader("C:\\multi-page-pdf.pdf");
     var signedPdf = new FileStream("C:\\multi-page-pdf-signed.pdf", FileMode.Create);
     var pdfStamper = PdfStamper.CreateSignature(pdfReader, signedPdf, '\0');
     PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;
     signatureAppearance.SignatureGraphic = Image.GetInstance("C:\\logo.png");
     signatureAppearance.Reason = "Because I can";
     signatureAppearance.Location = "My location";
     signatureAppearance.SetVisibleSignature(new Rectangle(100, 100, 250, 150), pdfReader.NumberOfPages, "Signature");
     signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.GRAPHIC_AND_DESCRIPTION;
     MakeSignature.SignDetached(signatureAppearance, externalSignature, chain, null, null, null, 0, CryptoStandard.CMS);
