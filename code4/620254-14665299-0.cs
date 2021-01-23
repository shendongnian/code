    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var myRegex = new Regex(@"^(\d)+\.\d-(\d){4}-\d$");
    
        if (myRegex.IsMatch(textBox1.Text))
        {
            //Validation is ok
        }
        else
        {
            //Validation isn't ok
        }
    }
