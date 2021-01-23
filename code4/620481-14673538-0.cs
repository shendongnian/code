    if (dr.IsNull("CellNumber"))
    {
        MessageBox.Show("Please enter Cell number");
    }
    else
    {
        dr["CellNumber"] = txtCellNo.Text; 
    }
    dr["CellNumber"] = txtCellNo.Text;//Argument exception is thrown here
    
