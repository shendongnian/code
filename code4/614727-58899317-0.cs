[STAThread]
public static void Main()
{
	StartSingleInstanceApplication<CntApplication>();
}
public static void StartSingleInstanceApplication<T>()
	where T : RichApplication
{
	DebuggerOutput.GetInstance();
	Assembly assembly = typeof(T).Assembly;
	string mutexName = $"SingleInstanceApplication/{assembly.GetName().Name}/{assembly.GetType().GUID}";
	Mutex mutex = new Mutex(true, mutexName, out bool mutexCreated);
	if (!mutexCreated)
	{
		mutex = null;
		var client = new NamedPipeClientStream(mutexName);
		client.Connect();
		using (StreamWriter writer = new StreamWriter(client))
			writer.WriteLine(string.Join("\t", Environment.GetCommandLineArgs()));
		return;
	}
	else
	{
		T application = Activator.CreateInstance<T>();
		application.Exit += (object sender, ExitEventArgs e) =>
		{
			mutex.ReleaseMutex();
			mutex.Close();
			mutex = null;
		};
		Task.Factory.StartNew(() =>
		{
			while (mutex != null)
			{
				using (var server = new NamedPipeServerStream(mutexName))
				{
					server.WaitForConnection();
					using (StreamReader reader = new StreamReader(server))
					{
						string[] args = reader.ReadToEnd().Trim().Split("\t", StringSplitOptions.RemoveEmptyEntries).ToArray();
						UIDispatcher.GetInstance().Invoke(() => application.ExecuteCommandLineArgs(args));
					}
				}
			}
		}, TaskCreationOptions.LongRunning);
		typeof(T).GetMethod("InitializeComponent").Invoke(application, new object[] { });
		application.Run();
	}
}
