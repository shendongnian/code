    public Form1()
    {
        InitializeComponent();
        this.FormClosing+=new FormClosingEventHandler(Form1_FormClosing);
    }
    void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
            MessageBox.Show("Unsave Work");
    } 
