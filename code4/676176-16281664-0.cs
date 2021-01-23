    public partial class Form1 : Form
    {
        DataTable dt = null;
        DataGridView dgv = null;
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
    
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;pwd=1234;database=test;"))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from MyTable;";
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                conn.Close();
            }
    
            dgv = new DataGridView();
            dgv.AllowUserToAddRows = false;
            dgv.CellEndEdit += new DataGridViewCellEventHandler(dgv_CellEndEdit);
            dgv.CellValidating += new DataGridViewCellValidatingEventHandler(dgv_CellValidating);
            dgv.Dock = DockStyle.Fill;
            dgv.DataSource = dt;
            this.Controls.Add(dgv);
        }
    
        void dgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgv.CancelEdit();
            }
        }
    
        void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string id = dt.Rows[e.RowIndex]["id"] + "";
            string col = dt.Columns[e.ColumnIndex].ColumnName;
            string data = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value+"";
    
            string sql = string.Format("UPDATE `MyTable` SET `{0}` = '{1}' WHERE ID = {2};", col, data, id);
    
            using (MySqlConnection conn = new MySqlConnection("server=localhost;user=root;pwd=1234;database=test;"))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
