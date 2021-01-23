        string path = "d:\\zipold.zip";
        ZipFile zipnew = ZipFile.Read("d:\\zipnew.zip");
        if (!File.Exists(path))
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.Save(path);
            }
        }
        string tmpname = "d:" + "\\temp.dat";
        ZipFile zipold = ZipFile.Read(path);
        foreach (ZipEntry zenew in zipnew)
        {
            string flna = zenew.FileName.ToString();
            //string tfn = '\\' + flna.Replace("\\", "/"); useless line
            Stream fstream = File.Open(tmpname, FileMode.OpenOrCreate, FileAccess.Write);
            zenew.Extract(fstream);
            string l = fstream.Length.ToString();
            fstream.Close();
            using (StreamReader sr = new StreamReader(tmpname))
            {
                var zn = zipold.UpdateEntry(flna, sr.BaseStream);
                zipold.Save();
                sr.Close();
                sr.Dispose();
                fstream.Dispose();
            }
        }
        zipnew.Dispose();
