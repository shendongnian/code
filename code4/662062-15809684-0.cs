    int custID;
    if(Int32.TryParse(SearchTextbox.Text, out custID))
       // CustomerID is a numeric field - no need to use single quotes
       dv.RowFilter = String.Format("CustomerID={0}", custID); 
    else
       // CustomerName is a string. Use single quotes and double the 
       // possible single quotes inside the search box
       dv.RowFilter = String.Format("CustomerName='{0}'", SearchTextbox.Text.Replace("'", "''") ;
    gridview1.DataSource = dv
