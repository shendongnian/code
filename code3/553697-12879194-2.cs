    // Event handler on your form
    private void button1_Click(object sender, EventArgs e)
    {
    	Button clickedButton = (Button)sender;
    	ButtonWasPressedOnForm(clickedButton);	
    }
    
    // Other method in your other class
    public void ButtonWasPressedOnForm(Button clickedButton)
    {
    	Form theParentForm = clickedButton.FindForm();
    	TextBox textBoxToUpdate = (TextBox)theParentForm.Controls.Find("txtBox1");
    	textBoxToUpdate.Text = "whatever";
    }
