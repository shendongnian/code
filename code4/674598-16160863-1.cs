     DataTable dt1;
     DataTable dt2;
     string[] ar=new string....
     foreach (DataRow dr in dt1.Rows)
     {
          foreach (DataColumn clm in dt1.Columns)
          {
              //loop through each value of the other table
              foreach(DataRow drow in dt2.Rows)
              {
                   string value = drow[0].ToString();
                   if(value==clm)
                   {
                        //add the column name into a array
                        ar[i]=clm.ColumnName
                   } 
              }
          }
     }
