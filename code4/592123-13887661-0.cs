    string xfile = System.IO.File.ReadAllText(strNewFilePath, System.Text.Encoding.Default);
    List<string> xmlContents;
    using (ZipFile zip = ZipFile.Read(this.uplZip.PostedFile.InputStream))
    {
        foreach (ZipEntry theEntry in zip)
        {
            using (var ms = new MemoryStream())
            {
                theEntry.Extract(ms);
    
                // The StreamReader will read from the current 
                // position of the MemoryStream which is currently 
                // set at the end of the string we just wrote to it. 
                // We need to set the position to 0 in order to read 
                // from the beginning.
                ms.Position = 0;
                var sr = new StreamReader(ms);
                var myStr = sr.ReadToEnd();
                xmlContents.Add(myStr);
            }
        }
    }
