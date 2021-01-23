    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
       if(TextBox1.Text.Trim().Length > 0)
       {
          Button.Enabled = true;
       }
    }
