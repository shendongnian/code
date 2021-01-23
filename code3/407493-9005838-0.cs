    public void button1_onClick(object sender, EventArgs e)
    {
        if (textBoxEmail.Text.ToUpper().IndexOf(textBoxName.Text.ToUpper()) >= 0)
           /* continue with processing */
        else
           /* display an error */
    }
