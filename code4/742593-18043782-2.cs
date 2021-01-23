    [STAThread]
    static void Main()
    {
        LoggedInUser = string.Empty;
        loginSuccess = false;
        String thisprocessname = Process.GetCurrentProcess().ProcessName;
        if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
            return;
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        MyApplicationContext context = new MyApplicationContext();
        //Add this event handler to create new message loop when the current is closed
        Application.ApplicationExit += (s,e) => {
           if(Program.loggedOut) {
              Program.MyApplicationContext ctxt = new Program.MyApplicationContext();
              Application.Run(ctxt);
           }
        };
        Application.Run(context);
    }
    //MyApplicationContext constructor
    public MyApplicationContext()
        {
                try
                {
                    lgFrm.ShowDialog();
                    if (lgFrm.LogonSuccessful)
                    {
                        ////lgFrm.Close();
                        lgFrm.Dispose();
                        FormCollection frm = Application.OpenForms;
                        try
                        {
                            foreach (Form fc in frm)
                                fc.Close();
                        }
                        catch (Exception ex){}
                        //Application.Run(new Main_Form());  <<<---- Remove this
                        MainForm = new Main_Form();
                    }
                }
                catch (Exception ex){}
         }
     //
     private void LogOutMenuItem_Click(object sender, EventArgs e)
     {
        Login_Form lgFrm = new Login_Form();
        lgFrm.LogonSuccessful = false;
        Program.loggedOut = true;
        Program.LoggedInUser = string.Empty;
        this.Close();  //I think you want to call Application.Restart() here?
                       //if so, you don't need the ApplicationExit event handler added in the Main() method.   
     }
         
