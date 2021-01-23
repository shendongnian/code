    public string EncryptPassword(string password, string saltorusername)
            {
                using (var sha256 = SHA256.Create())
                {
                    var saltedPassword = string.Format("{0}{1}", salt, password);
                    byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                    return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
                }
            }
