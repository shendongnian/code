    if (Directory.Exists(folder))
    {
      string pattern = ".xml";
      string machineName = System.Environment.MachineName;
      string[] files = Directory.GetFiles(folder, pattern, SearchOption.AllDirectories);  
      newExt = string.Format("{0}.{1}", machineName, newExt);
      for (int i = 0; i < files.Length; i++)
      {
          try
          {
              if (files[i].Contains(machineName))
              {
                   //replace this new extension
                   files[i].Replace(machineName + ".", "");
              }
              else
              {
                   files[i] = ChangeExtension(files[i], newExt, true);
              }
         catch(FileNotFoundException ex)
         {   
         } 
      }
      IEnumerable<string> sortedFiles = files.Where(f => !string.IsNullOrEmpty(f) && f.Contains(machineName))
                                             .OrderBy(f => f, Sorter);
    }
