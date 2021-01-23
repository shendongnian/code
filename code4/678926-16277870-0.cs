    DataTable myTable = myRow.Table;
    foreach (DataColumn nextCol in myTable.Columns)
    {
      // filter out Name, Age, ID, Salary
      // if nextCol is Name, Age, ID, or Salary
      // continue
      
      // add a label and text box for next column
      Label nextLabel = new Label();
      nextLabel.Text = nextCol.Caption;
      // add next label to your control
      // add a text box for the next column
      TextBox nextTb = new TextBox();
      // add next text box to your control
      // assume your table sets up columns as write enabled or read only
      nextTb.ReadOnly = nextCol.ReadOnly;
      // keep track of write enabled text boxes - SEE BELOW
      if (!nextCol.ReadOnly)
      {
        dataCols.Add(nextCol.Caption, nextCol);
        textBoxes.Add(nextCol.Caption, nextTb);
      }
    }
