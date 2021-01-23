    // retrieves the maximum number of characters that can be decrypted at once
    private int getMaxBlockSize(int keySize){
        int max = ((int)(keysize/8/3) )* 4
        if (keySize / 8 mod 3 != 0){
            max += 4
        }
        return max;
    }
     
    public string decrypt(string msg, string containerName){
        CspParameters params = new CspParameters();
        params.KeyContainerName = containerName;
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(params);
        StringBuilder decryptedMsg = new StringBuilder();
        int maxDecryptSize = getMaxBlockSize(rsa.KeySize);
        int iterationCount = Math.Floor(msg.length / maxDecryptSize)
        for(int i=0; i<iterationCount; i++){
            int start = i * maxDecryptSize;
            int blkSize = Math.min(start + maxDecryptSize, msg.Length);
            Byte[] msgBytes = System.Convert.FromBase64String(msg.Substring(start, blkSize));
            decryptedMsg.Append(System.Text.Encoding.Unicode.GetString(RSAProvider.Decrypt(msgBytes, false));
        }
        return decryptedMsg.ToString();
    }
