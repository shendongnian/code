    using(AesCryptoServiceProvider Aes = new AesCryptoServiceProvider()){
            Aes.Key = keyArray; 
            Aes.Mode = CipherMode.CBC; 
            Aes.Padding = PaddingMode.PKCS7; 
            Aes.IV = IV; 
            ICryptoTransform cTransform = Aes.CreateDecryptor(); 
            byte[] resultArray = cTransform.TransformFinalBlock(toDecryptArray, 0, toDecryptArray.Length); 
            Aes.Clear(); 
            return UTF8Encoding.UTF8.GetString(resultArray, 0, resultArray.Length); 
    }
