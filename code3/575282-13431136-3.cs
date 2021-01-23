    IDbCommand cmm = Linq.Connection.CreateCommand();
    try
    {           
       // define name and type of command
       cmm.CommandText = "SaveCards";
       cmm.CommandType = CommandType.StoredProcedure;
       // assign connection
       cmm.Connection = Linq.Connection;
       // define parameters
       cmm.Parameters.Add(new SqlParameter("@Barcode_Num", Barcode_Num));
       cmm.Parameters.Add(new SqlParameter("@Card_Status_ID", 2));
       cmm.Parameters.Add(new SqlParameter("@Card_Type_ID", Card_Type_ID));
       cmm.Parameters.Add(new SqlParameter("@SaveDate", Save_Date));
       cmm.Parameters.Add(new SqlParameter("@Save_User_ID", Save_User_ID));
       // only now - after all the setup - open the connection, read the data
       cmm.Connection.Open();
       IDataReader rdr = rdr = cmm.ExecuteReader();
       while (rdr.Read())
       {
          ....
       }
    }
