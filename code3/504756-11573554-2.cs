    public Form1()
    {
        InitializeComponent();
        this.FormClosing+=new FormClosingEventHandler(Form1_FormClosing);
    }
    void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            var result = MessageBox.Show("Unsave Work", "", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
                e.Cancel = true;      
        }
    } 
