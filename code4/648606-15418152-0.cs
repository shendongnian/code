           foreach (DataGridViewColumn col in grd1.Columns)
            {
                string myCol = col.Name;
                int myColLength = col.Name.Length;
                string myColMonth = myCol.Substring(myColLength - 2);
                int myIntColMonth;
                if (int.TryParse(myColMonth, out myIntColMonth) 
                    && myIntColMonth <= myMostRecentActualMonth)
                {
                    col.ReadOnly = true;
                }
                else
                {
                    col.ReadOnly = false;
                }
            }   
     
