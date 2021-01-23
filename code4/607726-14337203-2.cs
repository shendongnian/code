    string oldValue = "";
    private void textChanged(object sender, EventArgs e)
    {
        TextBox textBox = sender as TextBox;
        if(textBox != null)
        {
            string theText = textBox.Text;
            
            // Do something with OLD value here.
    
            // Finally, update the old value ready for next time.
            oldValue = theText;
        }
    }
