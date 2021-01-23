        using Excel = Microsoft.Office.Interop.Excel;
        public static void SaveGridToExcel(DataGridView DGV)
        {
            if (DGV.Rows.Count > 0)
            {
                string filename = "";
                SaveFileDialog SV = new SaveFileDialog();
                SV.Filter = "EXCEL FILES|*.xlsx;*.xls";
                DialogResult result = SV.ShowDialog();
                if (result == DialogResult.OK)
                {
                    filename = SV.FileName;
                    bool multiselect = DGV.MultiSelect;
                    DGV.MultiSelect = true;
                    DGV.SelectAll();
                    DGV.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                    Clipboard.SetDataObject(DGV.GetClipboardContent());
                    var results = System.Convert.ToString(Clipboard.GetData(DataFormats.Text));
                    DGV.ClearSelection();
                    DGV.MultiSelect = multiselect;
                    Microsoft.Office.Interop.Excel.Application XCELAPP = null;
                    Microsoft.Office.Interop.Excel.Workbook XWORKBOOK = null;
                    Microsoft.Office.Interop.Excel.Worksheet XSHEET = null;
                    object misValue = System.Reflection.Missing.Value;
                    XCELAPP = new Excel.Application();
                    XWORKBOOK = XCELAPP.Workbooks.Add(misValue);
                    XCELAPP.DisplayAlerts = false;
                    XCELAPP.Visible = false;
                    XSHEET = XWORKBOOK.ActiveSheet;
                    XSHEET.Paste();
                    XWORKBOOK.SaveAs(filename, Excel.XlFileFormat.xlOpenXMLWorkbook);
                    XWORKBOOK.Close(false);
                    XCELAPP.Quit();
                    try
                    {                      
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(XSHEET);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(XWORKBOOK);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(XCELAPP);
                    }
                    catch { }
                }
            }
        }
