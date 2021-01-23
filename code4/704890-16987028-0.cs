    private Contact ReadInput()
    {
        Contact contact = new Contact();
        contact.FirstName = txtFirstName.Text;
        contact.LastName = txtLastName.Text;
        contact.AddressData = new Address
            {
                Street = txtStreet.Text,
                City = txtCity.Text,
                ZipCode = txtZipCode.Text,
                Country = (Countries) cmbCountry.SelectedIndex
            };
        return contact;
    }
    private bool ValidateContact(Contact contact)
    {
        if ( !InputUtility.ValidateString( contact.FirstName ) )
        {
            MessageBox.Show( "You must enter a first name with atleast one character (not a blank)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error );
            txtFirstName.Focus();
            txtFirstName.Text = " ";
            txtFirstName.SelectAll();
            return false;
        }
        else if ( !InputUtility.ValidateString( contact.LastName ) )
        {
            MessageBox.Show( "You must enter a last name with atleast one character (not a blank)", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error );
            txtLastName.Focus();
            txtLastName.Text = " ";
            txtLastName.SelectAll();
            return false;
        }
        return true;
    }
    private void button1_Click( object sender, EventArgs e )
    {
        Contact contact = ReadInput();
        if ( ValidateContact( contact ) )
        {
            m_contacts.AddContact(contact);
            UpdateGUI();
        }
    }
