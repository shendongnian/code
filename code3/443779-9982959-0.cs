         public AesData GetAesData()
        {
            //Before assigned the key and IV you have to generate it first this way.
            _rijndaelObj.GenerateKey();
            _rijndaelObj.GenerateIV();
            string key = Encoding.ASCII.GetString(_rijndaelObj.Key);
            string iv = Encoding.ASCII.GetString(_rijndaelObj.IV);
            return new AesData(key, iv);
        }
