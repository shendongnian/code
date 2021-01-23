            foreach (DataRow row in myTable.Rows) 
            {
                 Double i = 0;
                 Double j = Convert.ToDouble(row["x"]);
                 int y = 1;
                 int aan = Convert.ToInt32(row["year"]);
                     if(y == aan) 
                     {
                        i = j + 2;
                     }
                 row["x"]=i;
                 row.EndEdit();
                 myTable.AcceptChanges();
            }
