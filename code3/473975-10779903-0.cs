        StreamWriter sw;
    
      if (!File.Exists(path))
                        {
        
                            sw = File.CreateText(path);
                        }
        
                        else
                        {
                            sw = File.AppendText(path);
        
                        }
          
                        sw.WriteLine(ex.Message);
                        sw.Flush();
                        sw.Close();
