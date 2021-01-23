    static void Main() 
    { 
        Application.EnableVisualStyles(); 
        Application.SetCompatibleTextRenderingDefault(false); 
        Application.Run(new MainScreen()); 
    } 
    public MainScreen()
    {
        Login loginForm = new LoginForm();
        if(loginForm.ShowDialog() == DialogResult.Cancel)
            Application.Exit();
        InitializeComponent();
    }
