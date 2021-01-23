        Point GetScreenPositionFromCell(Excel.Range cell, Excel.Application excel)
        {
            var wnd = excel.ActiveWindow;
            if (wnd != null)
            {
                var result = new Point
                {
                    X = wnd.PointsToScreenPixelsX((int)cell.Left),
                    Y = wnd.PointsToScreenPixelsY((int)cell.Top)
                };
                //cleanup
                Marshal.ReleaseComObject(wnd);
                wnd = null;
                return result;
            }
            throw new Exception("Error retrieving active Excel-window.");
        }
