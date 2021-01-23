            InitializeComponent();
            CreateTimer();
        }
        private void CreateTimer()
        {
            System.Windows.Forms.Timer ProcessChecker = new System.Windows.Forms.Timer();
            ProcessChecker.Tick += new System.EventHandler(ProcessChecker_Tick);
            ProcessChecker.Interval = 6000;    //set your required interval for checking
            ProcessChecker.Start(); //now start the timer            
        }
        void ProcessChecker_Tick(object sender, System.EventArgs e)
        {
            Process[] pro = Process.GetProcessesByName("notepad"); //place your processname at the place of notepad
            if (pro.Length > 0)
            {
                new Thread(GenerateReport).Start(); //it will generate report in parallel so your process will not be effected by its longer time to generate report and sending email
            }
        }
        private void GenerateReport()
        {
            //after generating report send email
            SendEmail();  //create it and then invoke it here
        }
