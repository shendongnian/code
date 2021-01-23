    cboTransaction_SelectionChangeCommitted(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(cboTransaction.SelectedValue);
    
        var bindinglist = new BindingList(db.Items.Where(i => i.TransactionId == id).ToList());
        bs.DataSource = bindinglist;
    
        bs.ResetBindings(false);
    }
