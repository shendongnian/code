    public Form1()
    {
        InitializeComponent();
        buttonTest1.CustomClick +=new CustomClickEventHandler(userControl1_ButtonClick);
            
    }
    private void  userControl1_ButtonClick(object sender, EventArgs e)
    {
        MessageBox.Show("Hello"); 
    }
