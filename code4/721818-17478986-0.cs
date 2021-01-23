    private void btnForm1_Click(object sender, System.EventArgs e)
    {
        
    // Create an instance of form 2
        Form2 form2 = new Form2();
     
        // Create an instance of the delegate
        form2.passControl = new Form2.PassControl(PassData);
     
        // Show form 2
        form2.Show();
    }
     
    private void PassData(object sender)
    {
        // Set de text of the textbox to the value of the textbox of form 2
        txtForm1.Text = ((TextBox)sender).Text;
    }
