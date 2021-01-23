    System.Text.StringBuilder hash = new System.Text.StringBuilder();
            System.Security.Cryptography.MD5CryptoServiceProvider md5provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new System.Text.UTF8Encoding().GetBytes(YourEntryString));
            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2")); //lowerCase; X2 if uppercase desired
            }
            return hash.ToString();
