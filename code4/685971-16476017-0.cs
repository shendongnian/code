    public event EventHandler myEvent;
    public Form2()
    {
        InitializeComponent();
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        // update data here 
        // inform form 2 about data added 
        if (myEvent != null)
        {
            myEvent(this,e);
        }
    }
