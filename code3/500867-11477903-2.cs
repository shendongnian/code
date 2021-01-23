    class Class1 : IDisposable
    { 
       public string config = "file.config";
       StreamWriter writer = new StreamWriter(config); 
       public void print (string log) 
       {
         writer.WriteLine(log);
       } 
    
       public void log_close() 
       { 
          Dispose();
       }
    
       public void Dispose() 
       { 
          if (writer != null)
             writer.Close();
    
          writer = null;
       }
    }
   
