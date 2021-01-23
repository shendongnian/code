    Button button1;
    Button button2;
    public Form1()
    {
        button1.Click += new EventHandler(button1_Click);
        button2.Click += new EventHandler(button2_Click);
    }
    void button2_Click(object sender, EventArgs e)
    {
        button1_Click(button1, null);
    }
    public void button1_Click(object sender, EventArgs e)
    {
        //Action when click occurs
    }
