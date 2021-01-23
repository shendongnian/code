    string csvContent = string.Empty; 
    if (File.Exists("SourceFilePath")) 
    { 
        StreamReader rd = new StreamReader("SourceFilePath", true); 
        csvContent = rd.ReadToEnd(); 
        rd.Close(); 
        var DestPath = HttpContext.Current.Server.MapPath("~/CSV Files/")+"MyFile.csv";     
        StreamWriter wr = new StreamWriter(DestPath, true); 
        StringBuilder sb = new StringBuilder(csvContent); 
        wr.WriteLine(sb.ToString()); 
        sb.Clear(); 
        wr.Close();
