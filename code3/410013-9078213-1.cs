    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            using(SqlCeConnection _conn = new SqlCeConnection(@"Data Source = |DataDirectory|\Database1.sdf")){
              _conn.Open();
              SqlCeCommand sqlcmd = _conn.CreateCommand();
              sqlcmd.CommandText = "SELECT ID, UserName FROM Table1";
              SqlCeResultSet rs = sqlcmd.ExecuteResultSet(ResultSetOptions.Scrollable);
              this.bindingSource1.DataSource = rs;
            }
        }
    }
