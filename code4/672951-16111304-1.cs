    bool mutexCreated = true;
	using (Mutex mutex = new Mutex(true, "eCS", out mutexCreated))
	{
		if (mutexCreated)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			SqlConnection con123 = new SqlConnection(con123.Metoda());
			Application.Run(new Form1());
		}
		else
		{
			DialogResult result = 
				MessageBox.Show("AApplication is already working!Do you want to reopen it?", "Caution!",
					                                MessageBoxButtons.OKCancel);
			if (result == DialogResult.OK)
			{
				foreach (Process p in System.Diagnostics.Process.GetProcessesByName("Name of application"))
				{
					try
					{
						p.Kill();
						Application.Run(new Form1());
					}
					catch (Win32Exception winException)
					{
						// process was terminating or can't be terminated - deal with it
					}
					catch (InvalidOperationException invalidException)
					{
						// process has already exited - might be able to let this one go
					}
				}
			}
		}
		try
		{
			con123.Open();
			con123.Close();
		}
		catch
		{
			MessageBox.Show("Cant connect to server!!!", "Error!");
			Application.Exit();
		}
	}
