    public Form1()
    {
        InitializeComponent();
    
        LoginForm loginForm = new LoginForm();
        DialogResult result = loginForm.ShowDialog();
        if (result != System.Windows.Forms.DialogResult.OK)
            Application.Exit();
    }
    
    private void CreateButton_Click(object sender, EventArgs e)
    {
        CreateForm createForm = new CreateForm();
        createForm.Show();
    }
    
    private void DeleteButton_Click(object sender, EventArgs e)
    {
        DeleteForm deleteForm = new DeleteForm();
        deleteForm.Show();
    }
    
    private void MoveButton_Click(object sender, EventArgs e)
    {
        MoveForm moveForm = new MoveForm();
        moveForm.Show();
    }
