    dynamic getCells()
            {
            activeWorksheet1 = ((Excel.Worksheet)Application.ActiveSheet);
            var CellZ = activeWorksheet1.Cells.Find(
                    "*",
                    System.Reflection.Missing.Value, Excel.XlFindLookIn.xlValues,
                    Excel.XlLookAt.xlWhole,
                    Excel.XlSearchOrder.xlByRows,
                    Excel.XlSearchDirection.xlPrevious,
                    false,
                    System.Reflection.Missing.Value,
                    System.Reflection.Missing.Value);
                return CellZ;
            }
