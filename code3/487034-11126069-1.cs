    using System.IO;
    using System.Security.Cryptography;
    
    ...
    public byte[] HashedFileWrite(string filename, Stream input)
    {
        var hash_algorithm = MD5.Create();
                
        using(var file = File.OpenWrite(filename))
        {
            byte[] buffer = new byte[4096];
            int read = 0;
    
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                hash_algorithm.TransformBlock(buffer, 0, buffer.Length, null, 0);
                file.Write(buffer, 0, read);
            }
    
            hash_algorithm.TransformFinalBlock(buffer, 0, buffer.Length);
        }
    
        return hash_algorithm.Hash;
    }
