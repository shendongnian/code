    protected void Button1_Click(object sender, EventArgs e)
    {
        if(Label1.Text.Length == 0)
            Label1.Text = TextBox1.Text;
        else
            Label1.Text += "," + TextBox1.Text;
    }
