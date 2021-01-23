    public bool readXLS(string FilePath)
    {
        FileInfo existingFile = new FileInfo(FilePath);
        using (ExcelPackage package = new ExcelPackage(existingFile))
        {
            //get the first worksheet in the workbook
            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
            int colCount = worksheet.Dimension.End.Column;  //get Column Count
            int rowCount = worksheet.Dimension.End.Row;     //get row count
            string queryString = "INSERT INTO tableName VALUES";        //Here I am using "blind insert". You can specify the column names Blient inset is strongly not recommanded
            string eachVal = "";
            bool status;
            for (int row = 1; row <= rowCount; row++)
            {
                queryString += "(";
                for (int col = 1; col <= colCount; col++)
                {
                    eachVal = worksheet.Cells[row, col].Value.ToString().Trim();
                    queryString += "'" + eachVal + "',";
                }
                queryString = queryString.Remove(queryString.Length - 1, 1);    //removing last comma (,) from the string
                if (row % 1000 == 0)        //On every 1000 query will execute, as maximum of 1000 will be executed at a time. 
                {
                    queryString += ")";
                    status = this.runQuery(queryString);    //executing query
                    if (status == false)
                        return status;
                    queryString = "INSERT INTO tableName VALUES";
                }
                else
                {
                    queryString += "),";
                }
            }
            queryString = queryString.Remove(queryString.Length - 1, 1);    //removing last comma (,) from the string
            status = this.runQuery(queryString);    //executing query
            return status;
        }
    }
