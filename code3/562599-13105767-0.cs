    private void btnClear_Click(object sender, EventArgs e)
    {
        lblOrdered.Visible = false;  
        if (lstCakes.SelectionMode == SelectionMode.One)
        {
            lstCakes.Items.Remove(lstCakes.SelectedItem);
        }
        else if (lstCakes.SelectionMode != SelectionMode.None)
        {
            foreach (object o in lstCakes.SelectedItems.OfType<object>().ToList())
                lstCakes.Items.Remove(o);
        }
    }
