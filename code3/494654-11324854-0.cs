    public void btnDeleteClick(object sender, EventArgs e)
        {
            // Iterate through the ListViewItem
            foreach (ListViewItem row in ListView1.Items)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("cbxID");
                if (cb != null && cb.Checked)
                {
                    // ListView1.DataKeys[item.DisplayIndex].Values[0].ToString()
                    try
                    {
    
                    }
                    catch (Exception err)
                    {
    
                    }
                }
            }
        }
