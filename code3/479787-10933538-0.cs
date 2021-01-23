    if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
    {
        MessageBox(......);
        // See the comment below
        textBox1.ResetText();    
        textBox2.ResetText();   
    } 
