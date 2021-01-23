    using (FileStream fs = new FileStream(strFilePath, FileMode.Create, FileAccess.Write))
    {
        using (StreamWriter sw = new StreamWriter(fs))
        {
            // write your content
            sw.Flush();
            sw.Close();
        }
        fs.Close();
    }
