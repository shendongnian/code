    string StringA { get; set; }
    public void button1_Click(object sender, EventArgs e)
    { 
       StringA = "help";
    }
    public void button2_Click(object sender, EventArgs e)
    {
        string b = "I need ";
        string c = b + StringA;
    }
