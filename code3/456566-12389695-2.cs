    [Serializable]
	public class ExceptionWrapper : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
		    var st = new StackTrace(args.Exception, true);
			var frame = st.GetFrame(0);
			var lineNumber = frame.GetFileLineNumber();
			var methodName = frame.GetMethod().Name;
          	if(methodName.Equals(args.Method.Name))
	        {
	            string msg = string.Format("{0} had an error @ {1}: {2}\n{3}", 
	                args.Method.Name, DateTime.Now, 
	                args.Exception.Message, args.Exception.StackTrace);
	            Trace.WriteLine(msg);
	        }
        } 
    }
