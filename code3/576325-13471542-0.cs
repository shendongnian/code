    public class AppHost : AppHostHttpListenerBase
    {
    	public AppHost() : base("Service", typeof(AppHost).Assembly) 
    	{
    	}
    	public override void Configure(Funq.Container container)
    	{
    		Plugins.Add(new RazorFormat());
    	}
    	static void AddP12 (string filename, string password, ushort port)
    	{
    		string dirname = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    		string path = Path.Combine(dirname, ".mono");
    		path = Path.Combine(path, "httplistener");
    		if (!Directory.Exists(path))
    		{
    			Console.WriteLine("Creating directory: " + path);
    			Directory.CreateDirectory(path);
    		}
    		X509Certificate2 x509 = null;
    		try {
    			x509 = new X509Certificate2 (filename, password);
    		} catch (Exception e) {
    			Console.Error.WriteLine ("error loading certificate [{0}]", e.Message);
    			return;
    		}
    		string target_cert = Path.Combine (path, String.Format ("{0}.cer", port));
    		if (File.Exists(target_cert)) 
    		{
    			Console.Error.WriteLine ("error: there is already a certificate for that port.");
    			return;
    		}
    		string target_pvk = Path.Combine (path, String.Format ("{0}.pvk", port));
    		if (File.Exists(target_pvk)) {
    			Console.Error.WriteLine ("error: there is already a certificate for that port.");
    			return;
    		}
    		using (Stream cer = File.OpenWrite (target_cert)) 
    		{
    			byte[] raw = x509.RawData;
    			cer.Write (raw, 0, raw.Length);
    		}
    		PrivateKey pvk = new PrivateKey();
    		pvk.RSA = x509.PrivateKey as RSA;
    		pvk.Save(target_pvk);			
    	}
    	public static void Main(string[] args)
    	{
    		string listeningOn = string.Empty;
    		if (args.Length == 1)
    			listeningOn = "http://*:" + args[0] + "/";
    		else if (args.Length == 3)
    		{
    			listeningOn = "https://*:" + args[0] + "/";
    			AddP12(args[1], args[2], Convert.ToUInt16(args[0]));
    		}
    		else
    		{
    			Console.WriteLine("Usage: [port] [p12 certificate] [p12 password]");
    			return;
    		}
    		AppHost appHost = new AppHost();
    		appHost.Init();
    		appHost.Start(listeningOn);
    		Console.WriteLine("Service Stack Server started at {0}, listening on {1}", DateTime.Now, listeningOn);
    		while (true) System.Threading.Thread.Sleep(100);
    	}
    }
