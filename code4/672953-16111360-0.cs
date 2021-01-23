        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        SqlConnection con123 = new SqlConnection(con123.Metoda());
        string ProgramName = "Tray minimizer.exe";
        bool mutCreated = false;
        Mutex mut = new Mutex(true, ProgramName, out mutCreated);
        bool runApp = true;
        if (!mutCreated)
        {
            DialogResult result = MessageBox.Show("Application is already working! Do you want to reopen it?", "Caution!", MessageBoxButtons.OKCancel);
    
            if (result == DialogResult.OK)
            {
                foreach (Process p in System.Diagnostics.Process.GetProcessesByName(ProgramName))
                {
                    try
                    {
                        p.Kill();
                    }
                    catch { }
                }
                mut.WaitOne(); // Wait for ownership of the mutex to be released when the OS cleans up after the process being killed
            }
            else
            {
                runApp = false;
            }
        }
    
        if (runApp)
        {
            Application.Run(new Form1());
    
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
    
            mut.ReleaseMutex();
        }
