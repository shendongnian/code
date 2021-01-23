                using (var aes = new AesManaged())
                {
                    aes.KeySize = 256;
                    aes.Mode = CipherMode.CBC;
                    aes.IV = iv;
                    aes.Key = passwordHash;
                    aes.Padding = PaddingMode.PKCS7;
