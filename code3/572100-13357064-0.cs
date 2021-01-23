    string input = textBox1.Text;
    
    if(String.IsNullOrWhiteSpace(input))
    {
        MessageBox.Show("Sorry! You have not given any input for perform action");
        return;
    }
    
    textBox2.Text = new String(input.Reverse().ToArray());
