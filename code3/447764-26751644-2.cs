    private void button1_Click_2(object sender, EventArgs e)
    {
        DataSet DtSetmatch = new DataSet();
        SQL.DataTable dttt = new SQL.DataTable();
        string selectedTable = cmbImportItemList.Text;
        using (SqlDataAdapter adater = new SqlDataAdapter("Select * from "+selectedTable, new SqlConnection(Properties.Settings.Default.connectionstring2)))
        {
            adater.Fill(dttt);
        }          
        Excel.Application oXL;
        Excel._Workbook oWB;
        Excel._Worksheet oSheet;
        oXL = new Excel.Application();
        oXL.Visible = true;            
        oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
        oSheet = (Excel._Worksheet)oWB.ActiveSheet;
        SQL.DataTable dtCategories = dttt.DefaultView.ToTable(true,dttt.Columns[0].ToString());
    
        foreach (SQL.DataRow category in dtCategories.Rows)
        {
            oSheet = (Excel._Worksheet)oXL.Worksheets.Add();
            oSheet.Name = category[0].ToString()
                .Replace(" ", "")
                .Replace("  ", "")
                .Replace("/", "")
                .Replace("\\", "")
                .Replace("*", "");                    
            string[] colNames = new string[dttt.Columns.Count];
            int col = 0;
            try
            {
                foreach (SQL.DataColumn dc in dttt.Columns) colNames[col++] = dc.ColumnName;////dc.ColumnName;
                char lastColumn = (char)(65 + dttt.Columns.Count - 1);
                oSheet.get_Range("A1", lastColumn + "1").Value2 = colNames;
                oSheet.get_Range("A1", lastColumn + "1").Font.Bold = true;
                oSheet.get_Range("A1", lastColumn + "1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;                            
                SQL.DataRow[] dr = dttt.Select(string.Format(""));
                string[,] rowData = new string[dr.Count<SQL.DataRow>(), dttt.Columns.Count];                            
                int rowCnt = 0;
                int redRows = 2;
                foreach (SQL.DataRow row in dr)
                {                                
                    for (col = 0; col < dttt.Columns.Count; col++)
                    {
                        rowData[rowCnt, col] = row[col].ToString();                                   
                    }
                    redRows++;
                    rowCnt++;                             
                }                            
                oSheet.get_Range("A2", lastColumn + rowCnt.ToString()).Value2 = rowData;
                oXL.Visible = true;
                oXL.UserControl = true;
                try
                {
                    oWB.SaveAs("C://Products.xlsx", AccessMode: Excel.XlSaveAsAccessMode.xlShared);
                }
                catch
                {
                }
                break;
            }
            catch (Exception aee)
            {
            }
            break;
        }                                   
    }
