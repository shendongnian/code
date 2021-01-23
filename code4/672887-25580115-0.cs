      void create()
        {
            string s = "";
        }
        void InitializeTimer()
        {
            oTimer = new System.Timers.Timer(interval);
            oTimer.AutoReset = true;
            oTimer.Enabled = true;
            oTimer.Elapsed += new System.Timers.ElapsedEventHandler(oTimer_Elapsed);
        }
        void oTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            CreateFileData();
        }
        void CreateFileData()
        {
            string path = @"C:\SimpleWcfService\SimpleWindowsService\bin\Release\Singh.txt";
            StreamWriter oStreamWriter = new StreamWriter(path, true);
            oStreamWriter.WriteLine(DateTime.Now.ToString());
            oStreamWriter.Close();
            oStreamWriter = null;
        }
