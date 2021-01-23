        DataTable dtbl;
        private void InitializeDataTable()
        {
            dtbl = new DataTable();
            dtbl.Columns.Add("1st Header");
            dtbl.Columns.Add("2nd Header");
            dtbl.Columns.Add("3rd Header");
            dgv.DataSource = dtbl;
        }
