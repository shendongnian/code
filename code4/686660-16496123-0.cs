    public Form1()
    {
        InitializeComponent();
        check();
    }
    private string check()
    {
        try
        {
            return String.Empty;
        }
        finally
        {
            MessageBox.Show("finally");
        }
    }
