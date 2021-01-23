    string GetSha1String(string input)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in GetHash(input))
                    stringBuilder.Append(b.ToString("X2"));
                return stringBuilder.ToString();
            }
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm obj = SHA1.Create();
            return obj.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
