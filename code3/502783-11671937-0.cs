    var cert = new X509Certificate2(@"path-to-your.p12", "password");
    
    var buffer = File.ReadAllBytes(Path.Combine(basePath, "manifest.json"));
    
    ContentInfo cont = new ContentInfo(buffer);
    var cms = new SignedCms(cont, true);
    var signer = new CmsSigner(SubjectIdentifierType.SubjectKeyIdentifier, cert);
        
    signer.IncludeOption = X509IncludeOption.ExcludeRoot;
    
    cms.ComputeSignature(signer);
    
    var myCmsMessage = cms.Encode();
    
    
    File.WriteAllBytes(Path.Combine(basePath, "signature"), myCmsMessage);
