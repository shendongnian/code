            // Loop through each table in the document, 
            // grab only text from cells in the first column
            // in each table.
            foreach (Table tb in docs.Tables)
            {
                for (int row = 1; row <= tb.Rows.Count; row++)
                {
                    var cell = tb.Cell(row, 1);
                    var listNumber = cell.Range.ListFormat.ListString;
                    var text = listNumber + " " + cell.Range.Text;
                    
                    dt.Rows.Add(text);
                }
            }
