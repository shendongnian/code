    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("column1", "Column name");
            dataGridView1.Columns.Add(CreateComboBox());
            //adding some rows:
            dataGridView1.Rows.Add("a");
            dataGridView1.Rows.Add("b");
        }
        private DataGridViewComboBoxColumn CreateComboBox()
        {
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            {
                combo.Name = "comboColumn";
                combo.HeaderText = "Selection";
                combo.DataSource = GetDataForComboBox();
                combo.DisplayMember = "Name";
                combo.ValueMember = "Id";
            }
            return combo;
        }
        private DataTable GetDataForComboBox()
        {
            //this is your method to get the data from database
            //in my exmaple I will simply add some example data:
            DataTable table = new DataTable("ExampleData");
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Rows.Add(1, "Name 1");
            table.Rows.Add(2, "Name 2");
            table.Rows.Add(3, "Name 3");
            return table;
        }
    }
