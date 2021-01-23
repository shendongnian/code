    private DataTable ExcelToDataTable(byte[] excelDocumentAsBytes, bool hasHeaderRow)
    {
        DataTable dt = new DataTable();
        string errorMessages = "";
        //create a new Excel package in a memorystream
        using (MemoryStream stream = new MemoryStream(excelDocumentAsBytes))
        using (ExcelPackage excelPackage = new ExcelPackage(stream))
        {
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[1];
            //check if the worksheet is completely empty
            if (worksheet.Dimension == null)
            {
                return dt;
            }
            //add the columns to the datatable
            for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
            {
                string columnName = "Column " + j;
                var excelCell = worksheet.Cells[1, j].Value;
                if (excelCell != null)
                {
                    var excelCellDataType = excelCell;
                    //if there is a headerrow, set the next cell for the datatype and set the column name
                    if (hasHeaderRow == true)
                    {
                        excelCellDataType = worksheet.Cells[2, j].Value;
                        columnName = excelCell.ToString();
                        //check if the column name already exists in the datatable, if so make a unique name
                        if (dt.Columns.Contains(columnName) == true)
                        {
                            columnName = columnName + "_" + j;
                        }
                    }
                    //try to determine the datatype for the column (by looking at the next column if there is a header row)
                    if (excelCellDataType is DateTime)
                    {
                        dt.Columns.Add(columnName, typeof(DateTime));
                    }
                    else if (excelCellDataType is Boolean)
                    {
                        dt.Columns.Add(columnName, typeof(Boolean));
                    }
                    else if (excelCellDataType is Double)
                    {
                        //determine if the value is a decimal or int by looking for a decimal separator
                        //not the cleanest of solutions but it works since excel always gives a double
                        if (excelCellDataType.ToString().Contains(".") || excelCellDataType.ToString().Contains(","))
                        {
                            dt.Columns.Add(columnName, typeof(Decimal));
                        }
                        else
                        {
                            dt.Columns.Add(columnName, typeof(Int64));
                        }
                    }
                    else
                    {
                        dt.Columns.Add(columnName, typeof(String));
                    }
                }
                else
                {
                    dt.Columns.Add(columnName, typeof(String));
                }
            }
            //start adding data the datatable here by looping all rows and columns
            for (int i = worksheet.Dimension.Start.Row + Convert.ToInt32(hasHeaderRow); i <= worksheet.Dimension.End.Row; i++)
            {
                //create a new datatable row
                DataRow row = dt.NewRow();
                //loop all columns
                for (int j = worksheet.Dimension.Start.Column; j <= worksheet.Dimension.End.Column; j++)
                {
                    var excelCell = worksheet.Cells[i, j].Value;
                    //add cell value to the datatable
                    if (excelCell != null)
                    {
                        try
                        {
                            row[j - 1] = excelCell;
                        }
                        catch
                        {
                            errorMessages += "Row " + (i - 1) + ", Column " + j + ". Invalid " + dt.Columns[j - 1].DataType.ToString().Replace("System.", "") + " value:  " + excelCell.ToString() + "<br>";
                        }
                    }
                }
                //add the new row to the datatable
                dt.Rows.Add(row);
            }
        }
        //show error messages if needed
        Label1.Text = errorMessages;
        return dt;
    }
