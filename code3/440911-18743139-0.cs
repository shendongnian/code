    if(!File.Exist(path))
        {
            File.Create(path).Dispose();
           using( TextWriter tw = new StreamWriter(path))
            {
              tw.WriteLine("The very first line!");
              tw.Close();
            }
    
    }
    
        else if (File.Exists(path))
        {
            using(TextWriter tw = new StreamWriter(path))
            {
              tw.WriteLine("The next line!");
              tw.Close(); 
            }
        }
