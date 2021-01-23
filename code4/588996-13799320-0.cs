    public Form1()
    {
        InitializeComponent();
        
        // This is only called once.
        InitializeListBox();
    }
    
    private void InitializeListBox()
    {
        listBox1.Items.Add("Januari");
        listBox1.Items.Add("Februari");
        listBox1.Items.Add("March");
        listBox1.Items.Add("April");
        listBox1.Items.Add("May");
        listBox1.Items.Add("June");
        listBox1.Items.Add("July");
        listBox1.Items.Add("August");
        listBox1.Items.Add("September");
        listBox1.Items.Add("Oktober");
        listBox1.Items.Add("November");
        listBox1.Items.Add("December");
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        int mnr = Convert.ToInt32(textBox1.Text);
        string mnm = Convert.ToString(listBox1.Items[mnr - 1]);
        textBox2.Text = mnm;
    }
