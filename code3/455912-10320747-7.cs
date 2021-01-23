    String signedMessage = ""; // load Base64 coded the message generated in Java here.
    
    byte[] message = Convert.FromBase64String(signedMessage);
    String messageString = Encoding.ASCII.GetString(message);
    
    String[] lines = Regex.Split(messageString, "\n");
    
    byte[] content = Convert.FromBase64String(lines[0]); // first line of the message were the content
    byte[] signature = Convert.FromBase64String(lines[1]); // second line were the signature
    
    RSACryptoServiceProvider rsaObj = new RSACryptoServiceProvider(2048);
    
    //Create a new instance of the RSAParameters structure.
    RSAParameters rsaPars = new RSAParameters();
    
    rsaPars.Modulus = Convert.FromBase64String("insert your modulus revealed in the Java example here");
    rsaPars.Exponent = Convert.FromBase64String("AQAB"); // Exponent. Should always be this.
    
    // Import key parameters into RSA.
    rsaObj.ImportParameters(rsaPars);
    
    // verify the message
    Console.WriteLine(rsaObj.VerifyData(Encoding.ASCII.GetBytes(lines[0]), "SHA1", signature));
