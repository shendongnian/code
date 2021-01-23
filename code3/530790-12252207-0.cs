    try
    {
             
               var path = Path.Combine(DirPath, string.Concat("\\Log_",DateTime.Now.ToString("MM_dd_yyyy"), ".txt"));
       
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    streamWriter.WriteLine("Time :" + DateTime.Now.ToString() + "  ");
                    streamWriter.WriteLine(LogMessage);
                    streamWriter.WriteLine(Environment.NewLine);
                }
    
    
    }
    catch(Exception ex)
    {
       Console.Write(ex.Message);
       throw ex;
    }
