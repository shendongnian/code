    SQLCon.Open();
    
    blah...blah...blah...blah...
    
    SqlTransaction Trans1 = MyItmDatas.WMSCon.BeginTransaction();
    
    MyDataAdapter1.UpdateCommand.Transaction = Trans1;
    MyDataAdapter1.InsertCommand.Transaction = Trans1;
    MyDataAdapter1.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
    
    MyDataAdapter1.RowUpdating += new SqlRowUpdatingEventHandler(OnRowUpdating);
    
    myDataGrid1.CurrentCell = myDataGrid1.FirstDisplayedCell;
    myDataGrid1.EndEdit();
    
    try
    {
    MyDataAdapter1.Update(ItemTable);
    Trans1.Commit();
    MessageBox.Show(" ITEMS UPDATED TO ....... ITEM MASTER ", " ITEM MASTER UPDATE ");
    }
    catch (Exception ex)
    {
    if (Trans1 != null)
    {
    Trans1.Rollback();
    }
    MessageBox.Show(ex.Message, "Item Master Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
    SQLCon.Close();
    MyDataAdapter1.RowUpdating -= new SqlRowUpdatingEventHandler(OnRowUpdating);
    myDataGrid1.Refresh();
