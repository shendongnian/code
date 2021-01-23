    private const string DIR = @"Content/Levels/";
    
    
    private void WriteFile()
    {        
         string filename = "dummy.txt";
         string targetDirectory = DIR + filename;
        
         if (!Directory.Exists(LEVELS_DIR))
            Directory.CreateDirectory(LEVELS_DIR);
        
         StringBuilder data = new StringBuilder();
         data.Append("foo");
        
         using (StreamWriter writer = new StreamWriter(filename, false))
         {
             writer.WriteLine(data);
         }
    }
