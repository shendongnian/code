    class LogWriter : IDisposable
    {
       public const string configFileName = "file.config";
       StreamWriter writer = new StreamWriter(configFileName);
     
       public void Print(string log) 
       {
         writer.WriteLine(log);
       }
    
       public void CloseLog() 
       { 
          writer.Close();
       }
    
       public void Dispose()
       {
          CloseLog();
       }
    }
