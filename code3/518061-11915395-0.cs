    public Form1()
    {
        InitializeComponent();
        richTextBox1.MouseWheel += new MouseEventHandler(richTextBox_MouseWheel);
        
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
    
    
    }
    void richTextBox_MouseWheel(object sender, MouseEventArgs e)
    {
    	     MessageBox.Show(e.Delta.ToString());
             // use this value to scroll
    
    	    }
