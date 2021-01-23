    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int vlera1 = Convert.ToInt32(textBox1.Text); //Initialize a new int of name vlera2 and set its value to (textBox1.Text as int)
        }
        catch (Exception EX)
        {
            MessageBox.Show(EX.Message); //(not required) Show the message from the exception in a MessageBox
        }
    }
    
    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        try
        {
            int vlera2 = Convert.ToInt32(textBox2.Text);  //Initialize a new int of name vlera2 and set its value to (textBox1.Text as int)
        }
        catch (Exception EX)
        {
            MessageBox.Show(EX.Message); //(not required) Show the message from the exception in a MessageBox
        }
    }
