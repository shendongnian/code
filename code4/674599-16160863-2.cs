     DataTable dt1;
     DataTable dt2;
     DataTable dt3;
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
                         DataRow row = dt3.NewRow();
                         row[0]=clm.ColumnName;
                         dt3.Rows.Add(row);
                         break;
                   } 
              }
          }
     }
