    foreach (string file in files)
    {
        var fileBytes = _client.GetFile("/" + file);
        using (FileStream fs = new FileStream(path +file + ".gttmp", FileMode.Create))
        {
            for (int i = 0; i < fileBytes.Length; i++)
            {
                fs.WriteByte(fileBytes[i]);
            }
            fs.Seek(0, SeekOrigin.Begin);
            for (int i = 0; i < fileBytes.Length; i++)
            {
                if (fileBytes[i] != fs.ReadByte())
                {
                    MessageBox.Show("Error writing data for " + file);
                    break;
                }
            }
        }
    }
