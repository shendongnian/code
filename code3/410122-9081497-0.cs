    public class YourViewModel
    {
        private SqlDataAdapter adapter;
        private DataTable table;
        private SqlCommandBuilder commandBuilder;
        public DataTable Table { get { return table; } set { table = value; } }
        public void LoadTable(string connectionString, string tableName, int[] primaryKeyColumns)
        {
            adapter = new SqlDataAdapter(string.Format("SELECT * FROM {0}", tableName), connectionString);
            table = new DataTable();
            adapter.Fill(table);
            List<DataColumn> primaryKeys = new List<DataColumn>();
            for (int i = 0; i < primaryKeyColumns.Length; i++) primaryKeys.Add(table.Columns[primaryKeyColumns[i]]);
            table.PrimaryKey = primaryKeys.ToArray();
            commandBuilder = new SqlCommandBuilder(adapter);
            commandBuilder.GetUpdateCommand();
        }
        public int Update()
        {
            if (table == null || table.Rows.Count == 0 || adapter == null) return 0;
            if (table.PrimaryKey.Length == 0)
            {
                throw new Exception("Primary Keys must be defined before an update of this nature can be performed");
            }
            else
            {
                return adapter.Update(table);
            }
        }
    }
