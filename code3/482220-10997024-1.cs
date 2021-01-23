    [STAThread] 
    static void Main() 
    {     
        Application.EnableVisualStyles();     
        Application.SetCompatibleTextRenderingDefault(false);     
        Application.Run(new MainForm()); 
    } 
    
    public void MainForm_Load(object sender, EventArgs e)
    {
         // The using statement will take care of closing and disposing the login form
         using(LoginForm f = new LoginForm())
         {
             if(f.ShowDialog() != DialogResult.OK)
             {
                  Application.Exit();
                  return;
             }
         }
    
         // continue with main form processing
    }
