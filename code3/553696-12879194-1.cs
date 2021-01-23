    // Event handler on your form
    private void button1_Click(object sender, EventArgs e)
    {
    	ButtonWasPressedOnForm(txtBox1);	
    }
    
    // Other method in your other class
    public void ButtonWasPressedOnForm(TextBox textBoxToUpdate)
    {
    	textBoxToUpdate.Text = "whatever";
    }
    
