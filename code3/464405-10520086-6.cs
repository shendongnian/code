    static string CalculateMD5(string filename)
    {
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(filename))
            {
                string result = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty).ToLower();
                return result;
            }
        }
    }
