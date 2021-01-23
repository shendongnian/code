    if(ValuesHaveChanged())
    {
        DialogResult result = MessageBox.Show("Data has been changed, do you wish to save changes?", "Save Changes",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            // HERE MY UPDATE CODE.
            ResetChangeDetection();
        }
    }
.
    private bool ValuesHaveChanged()
    {
        return this.isDirty;
        /*
        return ! 
        (
            this.savedName.Equals(NameTextbox.Text)
            && this.savedAddress.Equals(AddressTextbox.Text)
        )
        */
    }
