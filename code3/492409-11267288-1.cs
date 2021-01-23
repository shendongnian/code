    protected void Page_Load(object sender, EventArgs e)
    {
        userControl.StatusUpdated += new EventHandler(userControl_StatusUpdated);
    }
    void userControl_StatusUpdated(object sender, EventArgs e)
    {
        GetDate();
    }
    private void GetDate()
    {
        TextBox1.Text = DateTime.Today.ToString();
    }
