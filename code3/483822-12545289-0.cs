            [STAThread]
        static void Main()
        {
            DateTime current = DateTime.Now;
            DateTime today = new DateTime(2012,7,19);
            TimeSpan span = current.Subtract(today);
            if (span.Days<0)
            {
                MessageBox.Show("Please adjust Time then restart Aspects","Adjust Time");
                Process.Start("timedate.cpl").WaitForExit();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Idle += new EventHandler(Application_Idle);
                
                mainForm = new MainForm();
                mainForm.Closing += new CancelEventHandler(mainForm_Closing);
                
                #if !DEBUG
                TerminateKeymon();
                StartSerial();
                SetupDefaultValues();
                EmbeddedMessageBox(0);
                #endif
                
                Application.Run(mainForm);
            }
        }
        static void Application_Idle(object sender, EventArgs e)
        {
            Application.Idle -= Application_Idle;
            mainForm.toolStripProgressBar1.Increment(1);
            UnitInformation.SetupUnitInformation();
            mainForm.toolStripProgressBar1.Increment(1);
            Aspects.Unit.HddInfo.GetHddInfo();
            mainForm.toolStripProgressBar1.Increment(1);
            for (int i = 0; i < mainForm.Controls.Count; i++)
            {
                if (mainForm.Controls[i] is AbstractSuperPanel)
                {
                    try
                    {
                        var startMe = mainForm.Controls[i] as AbstractSuperPanel;
                        startMe.StartWorking();
                        mainForm.toolStripProgressBar1.Increment(1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + mainForm.Controls[i].ToString());
                    }
                }
            }
            mainForm.toolStripProgressBar1.Value = 0;
        }
