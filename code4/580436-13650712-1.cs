    RSACryptoServiceProvider x_alg = new RSACryptoServiceProvider(); 
 
    RSAParameters x_public_params = x_alg.ExportParameters(false); // or true
    RSAWrapper wrapForClient = new RSAWrapper {
        RsaWrap = x_public_params,
        Key = "1024", // or whatever size you have
        Cipher = "???", // whatever this field means per client specs
        Text = "???", // whatever this field means per client specs
    }
    // with simplifications....
    XmlSerializer xser = new XmlSerializer(typeof(RSAWrapper));
    xser.Serialize(File.Create(yourFileName), wrapForClient);
   
    
