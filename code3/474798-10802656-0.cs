    //public/Global datatable
    public DataTable myTable = new DataTable();
    public Form1()
        {
            InitializeComponent();
            //create myTable Columns
            myTable.Columns.Add("Name");
            myTable.Columns.Add("Age");
            myTable.Columns.Add("Number");
            //add one row
            myTable.Rows.Add(new object[] {"myName","myAge","myNumber"});
            bind to the datagridview
            dataGridView1.DataSource = myTable;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //display the number or rows in the datatable
            MessageBox.Show(myTable.Rows.Count.ToString());
        }
    }
