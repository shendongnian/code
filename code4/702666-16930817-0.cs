    var reader = new System.IO.StreamReader(filePath, System.Text.Encoding.UTF8);
    var text = reader.ReadToEnd();
    
    reader.Close();
    
    var writer = new System.IO.StreamWriter(filePath, false, System.Text.Encoding.UTF8);
    
    writer.Write(text);
    writer.Close();
