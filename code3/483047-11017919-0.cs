        private void init(DataGridView datagridview, IHave_A_DataTable x)
        {
            datagridview.DataSource = x.GetDataTable();
            datagridview.Columns[datagridview.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            datagridview.CurrentCell = datagridview[0, datagridview.RowCount - 1];
            x.Changed += new EventHandler((o, e) =>
            {
                IHave_A_DataTable sender = o as IHave_A_DataTable;
                sender.GetDataTable().AcceptChanges();
            });
        }
