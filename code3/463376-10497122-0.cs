    private void btnAdd_Click(object sender, EventArgs e)
    {
        ContactForm frmContact = new ContactForm();   
    
        if (frmContact.ShowDialog() == DialogResult.OK) //just one call
        {
            MessageBox.Show("OK", "Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
