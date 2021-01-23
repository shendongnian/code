    public partial class Form1 : Form
    {
        static BindingSource dataSource;
        static string dbView = "default";
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dgData.MultiSelect = false;
            dataSource = new BindingSource();
            dataSource.ListChanged += dataSource_ListChanged;
            RefreshData();
            dgData.DataSource = dataSource;
            dgData.Sort(dgData.Columns[1], ListSortDirection.Ascending);
        }
        void dataSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (dgData.Rows.Count > 0)
                dgData.CurrentCell = dgData.Rows[e.NewIndex].Cells[0];
        }
        protected void RefreshData()
        {
            dataSource.DataSource = DB.GetView(dbView);
        }
        private void insert_Click(object sender, EventArgs e)
        {
            DB.Insert(textBox1.Text);
            RefreshData();
        }
        private void update_Click(object sender, EventArgs e)
        {
            DB.UpdateRandomRow(textBox2.Text);
            RefreshData();
        }
    }
    class DB
    {
        static DataTable dt;
        static string conStr = "yourConnectionString";
        static SqlDataAdapter _adapter;
        static Random r = new Random(10);
        public static SqlDataAdapter CreateSqlDataAdapter(SqlConnection connection)
        {
            _adapter = new SqlDataAdapter();
            _adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            _adapter.SelectCommand = new SqlCommand(
                "SELECT * FROM test", connection);
            _adapter.InsertCommand = new SqlCommand(
                "INSERT INTO test (value) " +
                "VALUES (@value)", connection);
            _adapter.UpdateCommand = new SqlCommand(
                "UPDATE test SET [value] = @value " +
                "WHERE id = @id", connection);
            _adapter.InsertCommand.Parameters.Add("@value",
                SqlDbType.NVarChar, 50, "value");
            _adapter.UpdateCommand.Parameters.Add("@id",
                SqlDbType.Int, 4, "id").SourceVersion = DataRowVersion.Current;
            _adapter.UpdateCommand.Parameters.Add("@value",
                SqlDbType.NVarChar, 50, "value").SourceVersion = DataRowVersion.Current;
            return _adapter;
        }
        // random update, to demonstrate dynamic
        // repositioning
        public static DataTable UpdateRandomRow(string value)
        {
            var currentRandom = r.Next(dt.Rows.Count);
            dt.Rows[currentRandom].SetField<string>(1, value);
            using (var con = new SqlConnection(conStr))
            {
                con.Open();
                _adapter = CreateSqlDataAdapter(con);
                _adapter.Update(dt);
            }
            return dt;
        }
        internal static DataTable GetView(string dbView)
        {
            if (dt == null)
            {
                dt = new DataTable();
                using (var con = new SqlConnection(conStr))
                {
                    con.Open();
                    _adapter = CreateSqlDataAdapter(con);
                    _adapter.Fill(dt);
                }
            }
            return dt;
        }
        internal static void Insert(string value)
        {
            if (dt == null)
                GetView("");
            var dr = dt.NewRow();
            dr[1] = value;
            dt.Rows.Add(dr);
            using (var con = new SqlConnection(conStr))
            {
                con.Open();
                _adapter = CreateSqlDataAdapter(con);
                _adapter.Update(dt);
            }
        }
    }
