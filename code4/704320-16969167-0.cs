    Encoding enc = GetEncording(item.pathFile);
    File.WriteAllText(item.pathFile, 
              File.ReadAllText(item.pathFile, enc).Replace(item.OriginalContent, 
              item.ChangedContent), 
            enc);
