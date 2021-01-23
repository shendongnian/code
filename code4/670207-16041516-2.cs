           //this is just a list of punctuations. Database field never might not contains some of them. 
           string[] punct = new string[]{"[", "]" ,"(", ")", "{", "}", "<", ">", ":",
                ",", "-", "...", "!", "«", "»", "-", ".", "?", "\"", "'",  "'", ";", "/"};
            foreach (DataColumn column in table.Columns)
            {
                string colName = column.ColumnName;
                bool b = punct.Any(s => colName.Contains(s));
                var listOfPunct = punct.Where(s => colName.Contains(s)).ToList();
                foreach (string p in listOfPunct)
                {
                    colName = colName.Replace(p, "");
                }
                column.ColumnName = colName;
            }
