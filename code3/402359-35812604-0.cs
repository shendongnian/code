    internal static class ExecutingHash
    {
        public static string GetExecutingFileHash()
        {
            return MD5(GetSelfBytes());
        }
        private static string MD5(byte[] input)
        {
            return MD5(ASCIIEncoding.ASCII.GetString(input));
        }
        private static string MD5(string input)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] originalBytes = ASCIIEncoding.Default.GetBytes(input);
            byte[] encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes).Replace("-", "");
        }
        private static byte[] GetSelfBytes()
        {
            string path = Application.ExecutablePath;
            FileStream running = File.OpenRead(path);
            byte[] exeBytes = new byte[running.Length];
            running.Read(exeBytes, 0, exeBytes.Length);
            running.Close();
            return exeBytes;
        }
    }
