    [Serializable] 
    public class MyAspect : OnExceptionAspect 
    { 
        private static object marker = new object();
    
        public override void OnException(MethodExecutionArgs args) 
        { 
          if(!args.Exception.Data.Contains(marker)) 
          { 
            string msg = string.Format("{0} had an error @ {1}: {2}\n{3}",  
                args.Method.Name, DateTime.Now,  
                args.Exception.Message, args.Exception.StackTrace); 
     
            Trace.WriteLine(msg); 
            args.Exception.Data.Add(marker, marker);
          } 
     
        }  
    }
