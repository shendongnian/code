        protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == null) 
        {
            if (TextBox2.Text == null) 
            {
                errorMsg.InnerText = "Error" //use a span with runat server
            }
        }
    }
 
