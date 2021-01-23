        private Excel.Application App;
        private Excel.Range rng = null;
        private void button1_Click_1(object sender, EventArgs e) {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Filter = "Excel Worksheets|*.xls;*.xlsx;*.xlsm;*.csv";
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                App = new Excel.Application();
                App.Visible = true;
                App.Workbooks.Open(OFD.FileName);
            }
            else { return; }
            try { rng = (Excel.Range)App.InputBox("Please select a range", "Range Selection", Type: 8); }
            catch {  } // user pressed cancel on input box
            if (rng != null) { 
                DataTable dt = ConvertRangeToDataTable();
                if (dt != null) { dataGridView1.DataSource = dt; }
            }
            _Dispose();
        }
        private DataTable ConvertRangeToDataTable() {
            try {
                DataTable dt = new DataTable();
                int ColCount = rng.Columns.Count;
                int RowCount = rng.Rows.Count;
                for (int i = 0; i < ColCount; i++) {
                    DataColumn dc = new DataColumn();
                    dt.Columns.Add(dc);
                }
                for (int i = 1; i <= RowCount; i++) {
                    DataRow dr = dt.NewRow();
                    for (int j = 1; j <= ColCount; j++) { dr[j - 1] = rng.Cells[i, j].Value2; }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch { return null; }
        }
        private void _Dispose() {
            try { Marshal.ReleaseComObject(rng); }
            catch { }
            finally { rng = null; }
            try { App.Quit(); Marshal.ReleaseComObject(App); }
            catch { }
            finally { App = null; }
        }
