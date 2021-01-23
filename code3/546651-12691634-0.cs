     Range range = activeWorksheet.get_Range("Name", MissingValue);
     int totalMissingRows = 0;
                if (range.Rows.Count < result.Length)
                {
                    totalMissingRows = result.Length - range.Rows.Count;
                    for (int i = 0, l = totalMissingRows; i < l; i++)
                    {
    
                        Excel.Range rng = range;
                        rng = (Excel.Range)rng.Cells[rng.Rows.Count, 1];
                        rng = rng.EntireRow;
                        rng.Insert(Excel.XlInsertShiftDirection.xlShiftDown, MissingValue);
                    }
                }
    
                //delete extra lines
                //remove left over data
                for (int i = result.Length, l = range.Rows.Count; i < l; i++) { range.Cells[range.Rows.Count, 1].EntireRow.Delete(null); }
