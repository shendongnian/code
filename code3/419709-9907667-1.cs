    public partial class Form1 : Form
    {
        BindingSource bs;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            dt = new DataTable("Customers");
            DataColumn dc;
            dc = new DataColumn();
            dc.DataType = typeof(int);
            dc.ColumnName = "CustomerID";
            dt.Columns.Add(dc);
            dt.Columns.Add(new DataColumn("LastName"));
            dt.Columns.Add(new DataColumn("FirstName"));
            // Concatenation of first and last names 
            dt.Columns.Add(new DataColumn("FullName"));
            dt.Columns.Add(new DataColumn("Address"));
            dt.Columns.Add(new DataColumn("City"));
            dt.Columns.Add(new DataColumn("State"));
            dt.Columns.Add(new DataColumn("Zip"));
            dt.Columns.Add(new DataColumn("Phone"));
            dc = new DataColumn();
            dc.DataType = typeof(DateTime);
            dc.ColumnName = "LastPurchaseDate";
            dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.DataType = typeof(int);
            dc.ColumnName = "CustomerType";
            dt.Columns.Add(dc);
            dt.Columns.Add("HiddenSort", typeof(bool));
            // Populate the table 
            dt.Rows.Add(2, "Baggins", "Bilbo", "Baggins, Bilbo", "Bagshot Row #1", "Hobbiton", "SH", "00001", "555-2222", DateTime.Parse("9/9/2008"), 1, false);
            dt.Rows.Add(1, "Baggins", "Frodo", "Baggins, Frodo", "Bagshot Row #2", "Hobbiton", "SH", "00001", "555-1111", DateTime.Parse("9/9/2008"), 1, false);
            dt.Rows.Add(6, "Bolger", "Fatty", "Bolger, Fatty", "ProudFeet Creek", "Hobbiton", "SH", "00001", "555-1111", DateTime.Parse("9/9/2008"), 1); dt.Rows.Add(4, "Elessar", "Aragorn", "Elessar, Aragorn", "Citadel", "Minas Tirith", "Gondor", "00000", "555-0000", DateTime.Parse("9/9/2008"), 4, false);
            dt.Rows.Add(5, "Evenstar", "Arwin", "Evenstar, Arwin", "Citadel", "Minas Tirith", "Gondor", "00000", "555-0001", DateTime.Parse("9/9/2008"), 4, false);
            dt.Rows.Add(3, "Greyhame", "Gandalf", "Grayhame, Gandalf", DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, 3, false);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dataGridView1.DataSource = bs;
            dataGridView1.Columns["HiddenSort"].Visible = false;
            dataGridView1.Sorted += new EventHandler(dataGridView1_Sorted);
        }
        void dataGridView1_Sorted(object sender, EventArgs e)
        {
            foreach (DataRow dr in dt.Rows)
            {
                dr["HiddenSort"] = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.Rows.Add(2, "Testing", "Bilbo", "Baggins, Bilbo", "Bagshot Row #1", "Hobbiton", "SH", "00001", "555-2222", DateTime.Parse("9/9/2008"), 1, true);
            DataView dv = dt.DefaultView;
            if (dataGridView1.SortedColumn == null)
            {
                dv.Sort = "[HiddenSort] desc";
            }
            else
            {
                string sortname = dataGridView1.SortedColumn.Name;
            
                dv.Sort = "[HiddenSort] desc, [" + sortname + "] asc";
            }
        }
    }
