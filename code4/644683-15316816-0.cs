    foreach (DataRow row in dsGetAvailUsers.Tables[0].Rows) 
    {
    var item = new User();
     for (int j = 0; j < dsGetAvailUsers.Tables[0].Columns.Count; j++)
     {
       if(dsGetAvailUsers.Tables[0].Columns[j].ColumnName == "sUserId")
          item.sUserId = row ["sUserId"].ToString ();
       else if(dsGetAvailUsers.Tables[0].Columns[j].ColumnName == "UserDesc")
          item.UserDesc= row ["UserDesc"].ToString ();
       .....
     }
    
   
    listUsers.Add(item);
    }
