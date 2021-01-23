    public Invoice Invoice
    {
       set
       {
            txtFirstName.Text = value.FirstName;
            txtLastName.Text = value.LastName;
            txtCellNo.Text = value.CellNo;
            // etc
       }
    }
