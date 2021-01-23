        public void ExportToExcel()
        {
            var Excel = new Microsoft.Office.Interop.Excel.Application();
            XlReferenceStyle RefStyle = Excel.ReferenceStyle;
            Excel.Visible = true;
            Workbook wb = null;
            string path = "yourpath";
            try
            {
                wb = Excel.Workbooks.Add(path); 
            }
            catch (System.Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
            Worksheet ws = wb.Worksheets.get_Item(1) as Worksheet ;
            for (int j = 0; j < GridView1.Columns.Count; ++j)
            {
                (ws.Cells[1, j + 1] as Range).Value2 = GridView1.Columns[j].HeaderText;
                for (int i = 0; i < GridView1.Rows.Count; ++i) 
                {
                    object Val = GridView1.Rows[i].Cells[j].Value;
                    if (Val != null)
                        (ws.Cells[i + 2, j + 1] as Range).Value2 = Val.ToString();
                }
            }
            Excel.ReferenceStyle = RefStyle;
            Marshal.ReleaseComObject((object)Excel);         
            GC.GetTotalMemory(true); 
        }
