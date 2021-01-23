    public Form1()
    {
        InitializeComponent();
    
        if (mainForm == null)
        {
            mainForm = this;
        }
    }
    
    private static Form1 mainForm;
    public static Form1 MainForm
    {
        get
        {
            return mainForm;
        }
    }
    
    private void UpdateTextbox(string msg)
    {
        MainForm.textBox1.Text += msg + Environment.NewLine;
    }
