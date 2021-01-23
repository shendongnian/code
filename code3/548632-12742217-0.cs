        int dateTimeColumn = 3;
        for (int y = 0; y < dt.Columns.Count; y++)
        {
            string cellValue = dt.Rows[x][y].ToString();
            if(y == dateTimeColumn)
            {
                DateTime dateAndTime = DateTime.Parse(cellValue);
                cellValue = dateAndTime.ToShortDateString();
            }
            rowString += "\"" + cellValue + "\"";
            if (y != dt.Columns.Count - 1)
            {
                rowString += "~";
            }
        }  
