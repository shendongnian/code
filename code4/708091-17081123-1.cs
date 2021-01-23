    cboTransaction_SelectionChangeCommitted(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(cboTransaction.SelectedValue);
    
        db.Items.Where(i => i.TransactionId == id).Load();
        bs.DataSource = db.Items.Local.ToBindingList();
    
        bs.ResetBindings(false);
    }
