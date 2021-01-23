    // Event handler on your form
    private void button1_Click(object sender, EventArgs e)
    {
    	ButtonWasPressedOnForm(this);	
    }
    
    // Other method in your other class
    public void ButtonWasPressedOnForm(Form formWhereButtonPressed)
    {
    	formWhereButtonPressed.txtBox1 = "whatever";
    }
    
