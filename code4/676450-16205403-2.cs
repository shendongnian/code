    Assembly asm = Assembly.GetExecutingAssembly();
    string file = string.Format("{0}.UTReportTemplate.xls", asm.GetName().Name);
    Stream fileStream = asm.GetManifestResourceStream(file);
    SaveStreamToFile(@"c:\Temp\Temp.xls",fileStream);  //<--here is where to save to disk
    Excel.Application xlApp = new Excel.Application();
    xlWorkBook = xlApp.Workbooks.Open(@"c:\Temp\Temp.xls");
    if (xlWorkBook  == null)
    {
       MessageBox.Show("Error: Unable to open Excel file.");
       return;
    }
    //xlApp.Visible = false;
...
    public void SaveStreamToFile(string fileFullPath, Stream stream)
    {
        if (stream.Length == 0) return;
    
        // Create a FileStream object to write a stream to a file
        using (FileStream fileStream = System.IO.File.Create(fileFullPath, (int)stream.Length))
        {
            // Fill the bytes[] array with the stream data
            byte[] bytesInStream = new byte[stream.Length];
            stream.Read(bytesInStream, 0, (int)bytesInStream.Length);
    
            // Use FileStream object to write to the specified file
            fileStream.Write(bytesInStream, 0, bytesInStream.Length);
         }
    }
