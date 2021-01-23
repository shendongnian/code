    void Main()
    {
        UnicodeEncoding uniEncoding = new UnicodeEncoding();
        byte[] firstString = uniEncoding.GetBytes("This is the current contents of your TextBox");
        using(MemoryStream memStream = new MemoryStream(100))
        {
            memStream.Write(firstString, 0 , firstString.Length);
            // Reposition the stream at the beginning (otherwise an empty file will be created in the zip archive
            memStream.Seek(0, SeekOrigin.Begin);
            using (ZipFile zip = new ZipFile())
            {
                ZipEntry entry= zip.AddEntry("TextBoxData.txt", memStream);
                zip.Save(@"D:\temp\memzip.zip");  
            }
         }
    }
