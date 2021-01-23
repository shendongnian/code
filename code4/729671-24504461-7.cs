            // Method in Crypto class
            public static string HashPassword(string password)
            {
                if (password == null)
                {
                    throw new ArgumentNullException("password");
                }
    
                // Produce a version 0 (see comment above) password hash.
                byte[] salt;
                byte[] subkey;
                using (var deriveBytes = new Rfc2898DeriveBytes(password, SaltSize, PBKDF2IterCount))
                {
                    salt = deriveBytes.Salt;
                    subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
                }
    
                byte[] outputBytes = new byte[1 + SaltSize + PBKDF2SubkeyLength];
                Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
                Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, PBKDF2SubkeyLength);
                return Convert.ToBase64String(outputBytes);
            }
