                using (var aes = new AesManaged())
                {
                    aes.Mode = CipherMode.CBC;
                    aes.IV = iv;
                    aes.Key = passwordHash;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.KeySize = 256;
