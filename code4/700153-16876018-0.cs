    Form Code
    public string ID
    {
        get { return textBox1.Text; }
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        userControl11.ID = ID;
    }
    Usercontrol Code
    public string BorrowerID
    {
        set { textBox1.Text = value; }
    }
