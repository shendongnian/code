    public ArrayList FindDuplicateRows(DataTable dTable, string colName)
    {
       Hashtable hTable = new Hashtable();
       ArrayList duplicateList = new ArrayList();
       //add duplicate item value in arraylist.
       foreach (DataRow drow in dTable.Rows)
       {
          if (hTable.Contains(drow[colName]))
             duplicateList.Add(drow);
          else
             hTable.Add(drow[colName], string.Empty); 
       }
    
          return duplicateList;
    }
