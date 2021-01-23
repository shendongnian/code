    //// Header column names
    int gridViewCellCount = yourGridView.Rows[0].Cells.Count;
    // string array to hold grid view column names.
    string[] columnNames = new string[gridViewCellCount];
    
    for (int i = 0; i < gridViewCellCount; i++)
    {
    	columnNames[i] = ((System.Web.UI.WebControls.DataControlFieldCell)(yourGridView.Rows[0].Cells[i])).ContainingField.HeaderText;
    }
