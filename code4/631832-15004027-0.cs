	public static void Start (string name, string args)
	{
		new Thread (() =>
		{
	        try {
	            var proc = new ProcessStartInfo {
	                    FileName = name,
	                    Arguments = args,
	                    RedirectStandardOutput = true,
	                    CreateNoWindow = false,
	                    RedirectStandardError = false,
	                    UseShellExecute = false,
	                    RedirectStandardInput = false,
	            };
	            using (var p = new Process ()) {
	            	p.StartInfo = proc;
	            	p.Start ();
	            	p.WaitForExit ();
	            }
	            _started++;
	        } catch (Exception ex) {
	            tw.WriteLine (ex.InnerException+Environment.NewLine+ex.Message + Environment.NewLine + ex.StackTrace, false);
	            tw.Flush();
	        }
	    }).Start ();
	}
