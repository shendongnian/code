    public void Textbox1_TextChanged(object sender, EventArgs e)
    {
       StringBuilder builder = new StringBuilder();
    
       ... //build string
       //now, even though the builder's ToString will produce a different reference,
       //we're making sure we don't unnecessarily change the text.
       if(builder.ToString != TextBox2.Text) 
          TextBox2.Text = builder.ToString();       
    }
    
    public void Textbox2_TextChanged(object sender, EventArgs e)
    {
       StringBuilder builder = new StringBuilder();
    
       ... //build string
       //now, even though the builder's ToString will produce a different reference,
       //we're making sure we don't unnecessarily change the text.
       if(builder.ToString != TextBox1.Text) 
          TextBox1.Text = builder.ToString();       
    }
