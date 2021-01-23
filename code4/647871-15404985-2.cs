    private string pVal;
    //getter and setter
    public string PassVal
    {
        get { return pVal; }
        set { pVal = value; }
    }
    
    //or event that you need
    private void Form2_Load(object sender, EventArgs e)
    {
        textBox1.Text = pVal;
    }
