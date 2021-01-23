    [Serializable]
    public class DatabaseExceptionWrapper : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
          if(!(args.Exception is CustomException))
          {
            string msg = string.Format("{0} had an error @ {1}: {2}\n{3}", 
                args.Method.Name, DateTime.Now, 
                args.Exception.Message, args.Exception.StackTrace);
    
            Trace.WriteLine(msg);
          }
    
          throw new CustomException("There was a problem");
        } 
    }
