    public string ComputeHash(string filename)
    {
        using(var sha1 = new SHA1CryptoServiceProvider())
        {
            byte[] fileData = File.ReadAllBytes(filename);
            string hash = BitConverter.ToString(sha1.ComputeHash(fileData));
            
        }
    }
