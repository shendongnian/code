            if (checkModifiers() && (checkKey(Keys.F3)))
            {
                Workbook wb = Globals.ThisAddIn.Application.ActiveWorkbook;
                Worksheet ws = Globals.ThisAddIn.Application.ActiveSheet;
                Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)Globals.ThisAddIn.Application.ActiveCell;
                int row = rng.Row;
                int column = rng.Column;
                Range cell = ws.Cells[row, column];
                cell.ColumnWidth = 50;
                try
                {
                    drd.Add("One");
                    drd.Add("Two");
                    drd.Add("Three");
                    Microsoft.Office.Interop.Excel.DropDown xlDropDown;
                    Microsoft.Office.Interop.Excel.DropDowns xlDropDowns;
                    xlDropDowns = ((Microsoft.Office.Interop.Excel.DropDowns)(ws.DropDowns(Missing.Value)));
                    xlDropDown = xlDropDowns.Add((double)cell.Left, (double)cell.Top, (double)cell.Width, (double)cell.Height, true);
                    for (int i = 0; i < drd.Count; i++)
                    {
                        xlDropDown.AddItem(drd[i], i+1);
                    }
                }catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
