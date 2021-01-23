            public static KeyIV GetKeyBytesFromPassword(string password, byte[] salt) {
            using (var aes = new AesCryptoServiceProvider()) {
                using (var deriveBytes = new Rfc2898DeriveBytes(password, salt)) {
                    var res = new KeyIV {
                        Key = deriveBytes.GetBytes(aes.KeySize / 8),
                        IV = deriveBytes.GetBytes(aes.BlockSize / 8)
                    };
                    return res;
                }
            }
        }
