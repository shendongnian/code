        string valid128BitString = "AAECAwQFBgcICQoLDA0ODw==";
        string inputValue = "Test";
        string keyValue = valid128BitString;
		
        byte[] byteValForString = Encoding.UTF8.GetBytes(inputValue);
        EncryptResult result = Aes128Utility.EncryptData(byteValForString, keyValue);
        EncryptResult encyptedValue = new EncryptResult();
        encyptedValue.IV = result.IV; //<--Very Important
        encyptedValue.EncryptedMsg = result.EncryptedMsg;
        string finalResult =Encoding.UTF8.GetString(Aes128Utility.DecryptData(encyptedValue, keyValue));
