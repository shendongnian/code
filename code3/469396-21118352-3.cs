            bool UseContains = false;
            int colCount = MyDataTable.Columns.Count;
          
             
            string likeStatement = (UseContains) ? " Like '%{0}%'" : " Like '{0}%'"; 
            for (int i = 0; i < colCount; i++)
            {
                string colName = MyDataTable.Columns[i].ColumnName;
                query.Append(string.Concat("Convert(", colName, ", 'System.String')", likeStatement));
                         
                if (i != colCount - 1)
                    query.Append(" OR ");
            }
            
            filterString = query.ToString();
