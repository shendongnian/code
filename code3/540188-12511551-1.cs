    protected void Button1_Click(object sender, EventArgs e)
    {
       TextBox TextBox1 = ContentPlaceHolder1.FindControl("TextBox1") as TextBox;
       if (TextBox1 != null)
       {
           Label1.Text = TextBox1.Text;
       }
    }
