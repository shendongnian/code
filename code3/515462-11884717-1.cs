    RSACryptoServiceProvider RSAVerifier = new RSACryptoServiceProvider();
    //Read public Key From Text File.
    StreamReader PubKeyReader = File.OpenText(txtPublicKeyFile.Text);
    string publicKey = PubKeyReader.ReadToEnd();
    //Adding public key to RSACryptoServiceProvider object.
    RSAVerifier.FromXmlString(publicKey);
    //Reading the Signature to verify.
    FileStream Signature = new FileStream(txtVerifySign.Text, FileMode.Open, FileAccess.Read);
    BinaryReader SignatureReader = new BinaryReader(Signature);
    byte[] SignatureData = SignatureReader.ReadBytes((int)Signature.Length);
    //Reading the Signed File for Verification.
    FileStream Verifyfile = new FileStream(txtVerifyFile.Text, FileMode.Open, FileAccess.Read);
    BinaryReader VerifyFileReader = new BinaryReader(Verifyfile);
    byte[] VerifyFileData = VerifyFileReader.ReadBytes((int)Verifyfile.Length);
    //Comparing.
    bool isValidsignature = RSAVerifier.VerifyData(VerifyFileData, "SHA1", SignatureData);
    if (isValidsignature)
    {
          Signature.Close();
          Verifyfile.Close();
    }
    else
    {
        Signature.Close();
        Verifyfile.Close();
    }
