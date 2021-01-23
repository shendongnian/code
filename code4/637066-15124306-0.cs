    private void btnAddToList_Click(object sender, EventArgs e)
    {
           // Test to ensure it isn't null.
           if(txtAddText.Text != String.EmptyOrNull)
           {
                // Declare a variable with the initial textbox value.
                string txtVar = txtAddText.Text;
    
                // Has the second textbox inherit value from other Textbox.
                txtNewText = txtVar
    
               // Now Add it to a Listbox.
               lstContainer.Items.Add(txtAddText.Text + DateTime.Now());
           }
           
           else 
           {
                // Null or Empty Character, Error Message.
                MessageBox.Show("Invalid Entry, please enter a valid entry");
           }
    }
