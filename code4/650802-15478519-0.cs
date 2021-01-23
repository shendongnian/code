    public Control_Center()
    {
        InitializeComponent();
        this.Visible = false;
        LoginForm lf = new LoginForm();
        var dialogResult = lf.ShowDialog();
        if (dialogResult == System.Windows.Forms.DialogResult.OK)
        {
            this.Visible = true;
        }
        else
        {
            Application.Exit();
        }
    }
 
