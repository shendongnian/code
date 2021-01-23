    using System.IO;
    using System.Security.Cryptography;
    
    public string checkMD5(string filename)
    {
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(filename))
            {
                return Encoding.Default.GetString(md5.ComputeHash(stream));
            }
        }
    }
