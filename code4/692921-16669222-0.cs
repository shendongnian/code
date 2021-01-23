    int id = 0;
    
    if (Int32.TryParse(comboBox1.Text, out id))
    {
        //we get valid integer from combobox
        newInvoice.SupplierId = id;
    
        dc.t_trackings.InsertOnSubmit(newInvoice);
        dc.SubmitChanges();
    }
    else
    {
        //wrong value handling code goes here
    }
