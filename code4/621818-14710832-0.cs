    StringBuilder s = new StringBuilder();
    foreach (string file in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
    {
        using (var md5 = MD5.Create())
        {
            using (var stream = File.OpenRead(file))
            {
                checksum = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                s.AppendLine(file + ": " + checksum);
            }
        }
    }
    MessageBox.Show(s.ToString());
