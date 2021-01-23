    private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e){
			try{
				Logger.Append(Severity.CRITICAL, "Unhandlable error : "+e.ExceptionObject);	
				
			}catch{}
    		Console.WriteLine("Unhandlable error : "+e.ExceptionObject);
			Environment.Exit(10);
		}
