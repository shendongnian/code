        filenames = Directory.GetFiles(@"C:\Input_Data\");
        foreach(string filename in filenames)
        {
            string FileExtension = Path.GetExtension(filename);
            if (FileExtension == ".DAT" || FileExtension == ".csv") 
                Dts.Variables["FileExist"].Value = 1;
        }
