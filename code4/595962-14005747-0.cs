    public class YourForm
    {
        private DataTable _table;
        public YourForm()
        {
            InitializeComponents();
            _table = BuildDataTable();
        }
        
        private DataTable BuildDataTable()
        {
            DataTable table = new DataTable("tbl_Event");
            table.Columns.Add("event_duration");
            table.Columns.Add("event_name");
            table.Columns.Add("event_filename");
            table.Columns.Add("event_fullpath");
            return table;
        }
        
        private void AppendText(string event_filename, String event_name, String event_fullpath)
        {
            if (lstResultLog.InvokeRequired)
                lstResultLog.Invoke(new AppendListHandler(AppendText), new object[] { event_filename, event_name, event_fullpath });
            else
            {
                DateTime event_time = DateTime.Now;
                lstResultLog.Items.Add(event_time + event_filename + event_name + event_fullpath);
                //Create new row
                var row = _table.NewRow();
                // Fill row values
                row["event_name"] = event_name;
                // Add row to table
                _table.Rows.Add(row);
            }
        }
    }
