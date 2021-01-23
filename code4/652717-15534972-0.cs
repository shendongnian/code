    using Microsoft.Office.Interop.Excel;
    
    namespace SimpleExcelExport
    {
        class Export
        {
            public Export(bool defaultBackgroundIsWhite)
            {
                this.defaultBackgroundIsWhite = defaultBackgroundIsWhite;
    
                app = new Application();
                app.Visible = true;
                workbook = app.Workbooks.Add(1);
                worksheet = (Worksheet)workbook.Sheets[1];
            }       
    
            public void Do(string excelName, System.Windows.Forms.Button[][] array)
            {
                for (int i = 0; i <= array.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= array[i].GetUpperBound(0); j++)
                    {
                        AddData(i, j, array[i][j]);
                    }
                }
    
                //app.SaveWorkspace(excelName);
            }            
    
            private void AddData(int row, int col, System.Windows.Forms.Button button)
            {
                row++;
                col++;
                Range range = worksheet.Cells[row, col];
                if (!defaultBackgroundIsWhite)
                range.Interior.Color = button.BackColor.ToArgb();
                else
                    range.Interior.Color = button.BackColor.Name != "Control" ? button.BackColor.ToArgb() : System.Drawing.Color.White.ToArgb();
                range.NumberFormat = "";
                worksheet.Cells[row, col] = button.Text;
            }
    
            private Application app = null;
            private Workbook workbook = null;
            private Worksheet worksheet = null;
            private Range workSheet_range = null;
            private bool defaultBackgroundIsWhite;
        }
    }
