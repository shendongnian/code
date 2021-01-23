    // Event handler on your form
    private void button1_Click(object sender, EventArgs e)
    {
    	ButtonWasPressedOnForm(this);	
    }
    
    // Other method in your other class
    public void ButtonWasPressedOnForm(Form formWhereButtonPressed)
    {
    	// To act on the text box directly:
    	TextBox textBoxToUpdate = (TextBox)formWhereButtonPressed.Controls.Find("textBox1");
    	textBoxToUpdate.Text = "whatever";
    	// Or, using the Form1.txtBox1 property.
    	formWhereButtonPressed.txtBox1 = "whatever";  
    }
    
