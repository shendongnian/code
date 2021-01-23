    int lastCol = sheet.UsedRange.Columns.Count;
            if(lastCol > 1)
            {
                for (int i = 1; i <= lastCol; i++)
                {
                    sheet.Columns[i].TextToColumns(Type.Missing, XlTextParsingType.xlDelimited, XlTextQualifier.xlTextQualifierNone);
                }
