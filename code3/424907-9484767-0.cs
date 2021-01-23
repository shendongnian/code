    static public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
    {
        byte[] encryptedData;
        //Create a new instance of RSACryptoServiceProvider.
        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        {
    
            //Import the RSA Key information. This only needs
            //toinclude the public key information.
            RSA.ImportParameters(RSAKeyInfo);
    
            //Encrypt the passed byte array and specify OAEP padding.  
            //OAEP padding is only available on Microsoft Windows XP or
            //later.  
            encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
        }
        return encryptedData;
    }
