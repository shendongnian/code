    public void Textbox1_TextChanged(object sender, EventArgs e)
    {
       ...
       TextBox2.Text = someString;
    }
    
    public void Textbox2_TextChanged(object sender, EventArgs e)
    {
       ...
       TextBox1.Text = someOtherString;
    }
