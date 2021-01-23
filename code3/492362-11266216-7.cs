    private void textBox1_Validating(object sender, CancelEventArgs e)
    {
        TextBox tBox = (TextBox)sender; 
        double tstDbl;
        if (!double.TryParse(tBox.Text, out tstDbl)) 
        {
            //handle bad input
        }
        else
        {
            //double value OK - do something
        }            
    }
