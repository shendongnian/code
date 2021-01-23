            Range FirstCell = YourWorkSheet.Range["A1"];  //Use the Header of the column you want instead of "A1", or even a name you give to the cell in the worksheet.
            List<string> ColumnValues = new List<string>();
            int i = 1;
            object CellValue = FirstCell.Offset[i, 0].Value;
            while (CellValue != null)
            {
                ColumnValues.Add(CellValue.ToString());
                i++;
                CellValue = FirstCell.Offset[i,0];
            }
