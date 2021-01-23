            Worksheet sheet = (Worksheet)workbook.Sheets[1];
            Range excelRange = sheet.UsedRange; 
            object[,] valueArray = (object[,])excelRange.get_Value(XlRangeValueDataType.xlRangeValueDefault);
            for (int i = 1; i <= excelRange.Rows.Count; i++)
            {
                if (valueArray[i, 1] is Double)
                {                   
                    if (!valueArray[i, 1].ToString().Contains("."))
                    {
                        sb.AppendLine(valueArray[i, 1].ToString()); 
                    }
                }
            }
