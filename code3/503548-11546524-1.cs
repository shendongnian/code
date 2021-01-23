    dtDetails = getDataSet();
    
    foreach (DataRow dr in dtDetails.Rows) {
    
        int rowID = 1;
        HtmlTableRow row = new HtmlTableRow();
        {
            HtmlTableCell cell = new HtmlTableCell();
            TextBox tb = new TextBox();
          
            tb.ID = "tbJanuary" + rowID;
    
            tb.Text = dr["Jan"].ToString();
            tb .Attributes.Add("readonly", "readonly");
            cell.Controls.Add(tb);
            row.Cells.Add(cell);
        }
    }
