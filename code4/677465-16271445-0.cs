    var replaces = new Dictionary<string, string>() { { "A", "B" }, { "C", "D" }, {"E","F"} };
    var files = Directory.GetFiles(@"C:\Folder\", "*.txt",SearchOption.AllDirectories);
    foreach (var file in files) 
    {
      var text = File.ReadAllText(file);
           
      foreach (KeyValuePair<string, string> ky in replaces)
      {
           text = text.Replace(ky.Key.ToString(), ky.Value.ToString());
      }
    
      string [] splittedpath = file.ToString().Split('\\');
    
      string DirectoryPath = @"C:\Folder\Replaced Files\";
      string FilePath = "";
    
      for (int i = 0 ; i < splittedpath.Length ; i++)
      {
          if (i != 0 && i != 1 && i != (splittedpath.Length -1))
          {
              DirectoryPath = DirectoryPath + splittedpath[i].ToString() + @"\"; 
          }
    
           if(i == (splittedpath.Length -1))
           {
               FilePath = DirectoryPath + splittedpath[i].ToString();
           }
      }
    
      Directory.CreateDirectory(DirectoryPath);
      File.WriteAllText(FilePath, text);
    }
