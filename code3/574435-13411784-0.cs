         OleDbDataAdapter da = new OleDbDataAdapter("select * from [Sheet1$]", con);
         da.Fill(dtl);
        if ((dtl.Table.Count >= 1)
         {    
              if (ds.Tables[0].Rows.Count > 0)
              {
                 //Excel contains data
              }
              else
              {
                 //file is empty
              }   
         }
         else
         {
           //file is empty
         }
