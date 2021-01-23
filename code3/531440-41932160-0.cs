		public static void Connect(string host, int port, string user, string passPhrase, string privateKeyFilePath) {
			var keyFiles = new[] { new PrivateKeyFile(privateKeyFilePath, passPhrase) };
			var methods = new List<AuthenticationMethod>();
			methods.Add(new PasswordAuthenticationMethod(user, passPhrase));
			methods.Add(new PrivateKeyAuthenticationMethod(user, keyFiles));
			var con = new ConnectionInfo(host, port, user, methods.ToArray());
			var client = new SshClient(con);
			client.Connect();
			// create an xterm shell
			var Shell = client.CreateShellStream("xterm", 80, 24, 800, 600, 1024);
			// for reading & writing to the shell
			var reader = new StreamReader(Shell);
			var writer = new StreamWriter(Shell);
			// ....
			client.Disconnect();
		}
