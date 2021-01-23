        static bool Compare3(string filePath1, string filePath2)
        {
            byte[] hash1 = GenerateHash(filePath1);
            byte[] hash2 = GenerateHash(filePath2);
            if (hash1.Length != hash2.Length)
            {
                return false;
            }
            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] != hash2[i])
                {
                    return false;
                }
            }
            return true;
        }
        static byte[] GenerateHash(string filePath)
        {
            MD5 crypto = MD5.Create();
            using (FileStream stream = File.OpenRead(filePath))
            {
                return crypto.ComputeHash(stream);
            }
        }
