    MemoryStream memoryStream = new MemoryStream();
    TextWriter textWriter = new StreamWriter(memoryStream);
    textWriter.WriteLine("Something");   
    textWriter.Flush(); // added this line
    byte[] bytesInStream = memoryStream.ToArray(); // simpler way of converting to array
    memoryStream.Close(); 
    Response.Clear();
    Response.ContentType = "application/force-download";
    Response.AddHeader("content-disposition", "attachment;    filename=name_you_file.xls");
    Response.BinaryWrite(bytesInStream);
    Response.End();
