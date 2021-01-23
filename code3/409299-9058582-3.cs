    private void BtnFilterAndSort_Click(object sender, System.EventArgs e)
    {
      string  strText;
      string  strExpr;
      string  strSort;
      DataRow[] foundRows;
      DataTable myTable;
      myTable = ds.Tables["Orders"];
      // Setup Filter and Sort Criteria
      strExpr = "OrderDate >= '01.03.1998' AND OrderDate <= '31.03.1998'";
      strSort = "OrderDate DESC";
     
      // Use the Select method to find all rows matching the filter.
      foundRows = myTable.Select(strExpr, strSort);
      // Apply all Columns to the TextBox, this
      // must be done Row-By-Row.
      strText = null;
      for (int i = 0 ; i <= foundRows.GetUpperBound(0); i++)
      {
        for (int j = 0; j <= foundRows[i].ItemArray.GetUpperBound(0); j++)
        {
          strText = strText + foundRows[i][j].ToString() + "\t";
        }
        strText = strText + "\r\n";
        textBox.Text = strText;
      }
    }
