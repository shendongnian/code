	protected void Application_Error(object sender, EventArgs e)
	{
		Exception ex = Server.GetLastError();
		if (null == ex || ex is ThreadAbortException)
		{
			// could be due to redirect
			return;
		}
		if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 404)
		{
			// don't want to log this
			return;
		}
		LogException(ex);
	}
	private void LogException(Exception exception)
	{
		if (exception is ReflectionTypeLoadException)
		{
			foreach (Exception loaderException in ((ReflectionTypeLoadException)exception).LoaderExceptions)
			{
				LogException(loaderException);
			}
            if (null != exception.InnerException)
            {
                LogException(exception);
            }
		}
		else if (null != exception.InnerException)
		{
			LogException(exception.InnerException);
		}
		
		// you might also choose System.Console.WriteLine(...), System.Diagnostics.Trace.WriteLine(...), etc.
		System.Diagnostics.Debug.WriteLine(exception.Message);
		
		// or send to your favorite logger...this is log4net
		Log.FatalFormat("Unhandled error in the website: {0}", exception);
	}
