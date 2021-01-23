    protected void submit_Click(object sender, EventArgs e)
    {
        foreach (Control x in FindControl("Panel1").FindControl("Table1").Controls)
        {
            Label theLabel;
            RadNumericTextBox theRadNumericTextBox;
            if (x is RadNumericTextBox)
            {
                RadNumericTextBox theRadNumericTextBox = x as RadNumericTextBox;
                string val = theRadNumericTextBox.Text;
            }
            if (x is Label)
            {
                Label theLabel = x as Label;
                string valLabel = theLabel.Text;
            }
            // Either store up in a list or save to the database on each loop; it is recommended to store a list and send all the changes at once for a database save, but that is your choice
        }
    }
    
