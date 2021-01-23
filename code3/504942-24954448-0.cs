    private void LogIfError<TResult>(DbCommand command, DbCommandInterceptionContext<TResult> interceptionContext)
    {
    	if (interceptionContext.Exception != null)
    	{
    		var commandDumper = new DbCommandDumper(command);
    		Log.Warn(Command failed:\r\n{0}", commandDumper.GetLogDump());
      		// Exception will get logged further up the stack
    	}
    }
