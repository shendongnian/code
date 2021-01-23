         public static bool executeMyQuery(string sqlQuery)
          {
            try
            {        con.Open();
                     SqlCommand s = new SqlCommand(sqlQuery, con);
                     s.ExecuteNonQuery();
                     con.Close();
                     return true;
             } 
           catch()
            {
              return false;
            }
    
        And use the above function[executeMyQuery()] anywhere you want to insert like and check whether record is inserted or not like below:
    
         bool isInserted = false;
         // give dummy value or get it what u want to inser on name1,nam2,dat
         string rawQuery = string.Format("INSERT into NumbersTable values ('{0}', '{1}','{2}')",name1,nam2,dat );";
    
    isInserted = myExecuteQuery(rawQuery);
    
    if(isInserted)
    { 
       // lblStatus i am taking only to make you understand
       // lblStatus.text = "Record inserted succesfully"
    }
    else
    {
    // lblStatus.text = "Record insertion failed"
    }
