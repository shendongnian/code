    protected void Button1_Click(object sender, EventArgs e)
    {
       TextBox TextBox1 = (TextBox)ContentPlaceHolder1.FindControl("TextBox1");
       if (TextBox1 != null)
       {
           Label1.Text = TextBox1.Text;
       }
    }
