    private void OnTestButtonClicked(object sender, EventArgs e)
    {
    	Form myForm = new Form();
    	myForm.Text = "My Form Title";
    
    	// Add a checkbox
    	CheckBox checkBox = new CheckBox();
    	checkBox.Text = "Check me";
    	checkBox.Location = new Point(10, 10);
    	myForm.Controls.Add(checkBox);
    
    	// Show the form
    	myForm.Show();
    }
