                X509Store store = new X509Store(StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection sel = X509Certificate2UI.SelectFromCollection(store.Certificates, null, null, X509SelectionFlag.SingleSelection);
                X509Certificate2 cert = sel[0];
				
                Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
                Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] {
				cp.ReadCertificate(cert.RawData)};
                IExternalSignature externalSignature = new X509Certificate2Signature(cert, "SHA-1");
                PdfReader pdfReader = new PdfReader(pathToBasePdf);
                signedPdf = new FileStream(pathToBasePdf, FileMode.Create);
                pdfStamper = PdfStamper.CreateSignature(pdfReader, signedPdf, '\0');
                PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;
                signatureAppearance.SignatureGraphic = Image.GetInstance(pathToSignatureImage);
                signatureAppearance.SetVisibleSignature(new Rectangle(100, 100, 250, 150), pdfReader.NumberOfPages, "Signature");
                signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.GRAPHIC_AND_DESCRIPTION;
                MakeSignature.SignDetached(signatureAppearance, externalSignature, chain, null, null, null, 0, CryptoStandard.CMS);
