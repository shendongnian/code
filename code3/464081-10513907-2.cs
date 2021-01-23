    long totalSize = 0;
    foreach (string path in filePaths)
        totalSize += new FileInfo(path).Length + 1; // +1 = \n
    StringBuilder sb = new StringBuilder(Convert.ToInt32(totalSize));
    foreach (string path in filePaths)
    {
        using (StreamReader fs = new StreamReader(path))
        {
            string  file_text = fs.ReadToEnd();
            combinetexts.Append(file_text).Append("\n");
        }
    }
