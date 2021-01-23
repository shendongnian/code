    using System.Security.Cryptography.X509Certificates;
    using EU.Europa.EC.Markt.Dss;
    using EU.Europa.EC.Markt.Dss.Signature;
    using EU.Europa.EC.Markt.Dss.Signature.Cades;
    using EU.Europa.EC.Markt.Dss.Signature.Token;
     
       private static void SignP7M(X509Certificate2 card, string sourcepath)
                {
                    var service = new CAdESService();
        
                    // Creation of MS CAPI signature token
                    var token = new MSCAPISignatureToken { Cert = card };
        
                    var parameters = new SignatureParameters
                    {
                        SignatureAlgorithm = SignatureAlgorithm.RSA,
                        SignatureFormat = SignatureFormat.CAdES_BES,
                        DigestAlgorithm = DigestAlgorithm.SHA256,
                        SignaturePackaging = SignaturePackaging.ENVELOPING,
                        SigningCertificate = Org.BouncyCastle.Security.DotNetUtilities.FromX509Certificate(token.Cert),
                        SigningDate = DateTime.UtcNow
                    };
        
                    var toBeSigned = new FileDocument(sourcepath);
        
                    var iStream = service.ToBeSigned(toBeSigned, parameters);
        
                    var signatureValue = token.Sign(iStream, parameters.DigestAlgorithm, token.GetKeys()[0]);
        
                    var signedDocument = service.SignDocument(toBeSigned, parameters, signatureValue);
        
                    var dest = sourcepath + ".p7m";
                    if (File.Exists(dest)) File.Delete(dest);
                    var fout = File.OpenWrite(dest);
                    signedDocument.OpenStream().CopyTo(fout);
                    fout.Close();
                }
