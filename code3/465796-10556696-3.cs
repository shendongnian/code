    HashAlgorithm hashAlgorithm = new SHA256Managed();
    HashSet<string> hashSet = new HashSet<string>();
    string tempFilePath = filepath + ".tmp";
    using (var fs = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
    using (var sw = new StreamWriter(fs))
    {
        foreach (string line in File.ReadLines(filepath))
        {
            byte[] lineBytes = Encoding.UTF8.GetBytes(line);
            byte[] hashBytes = hashAlgorithm.ComputeHash(lineBytes);
            string hash = Convert.ToBase64String(hashBytes);
            if (hashSet.Add(hash))
                sw.WriteLine(line);
        }
    }
    File.Delete(filepath);
    File.Move(tempFilePath, filepath);
