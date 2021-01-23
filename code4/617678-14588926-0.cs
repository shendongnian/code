    conn.Open();
    OleDbDataAdapter DA = new OleDbDataAdapter("SELECT * FROM Prod.txt", conn);
    DataTable DT = new DataTable();
    DA.Fill(DT);
    DT.DefaultView.Sort = "Item/Variant ASC";
    Hashtable tempTable = new Hashtable();
    ArrayList duplicateList = new ArrayList();
    foreach (DataRow drow in DT.Rows)
     {
      if (tempTable.Contains(drow[yourcolName]))
         duplicateList.Add(drow);
      else
         tempTable.Add(drow[colName], string.Empty); 
     }
    //Removes the duplicates from Datatable...
    foreach (DataRow dRow in duplicateList)
      DT.Rows.Remove(dRow);
    
    ds.Tables.Add(DT);
    conn.Close();
