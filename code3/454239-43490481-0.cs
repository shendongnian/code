        /// <summary>
        /// Compute hash for string encoded as UTF8
        /// </summary>
        /// <param name="input">String to be hashed.</param>
        /// <returns>40-character hex string.</returns>
        public static string GetSha1(string input)
        {
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha1.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
