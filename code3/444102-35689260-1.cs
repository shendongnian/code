    public Form1()
            {
                InitializeComponent();
                //creating a test DataTable and adding an empty row
                DataTable dt = new DataTable();
                dt.Columns.Add("Column1");
                dt.Columns.Add("Column2");
                dt.Rows.Add(dt.NewRow());
                //binding to the gridview
                dataGridView1.DataSource = dt;
        
                //Set  the property AllowUserToAddRows to false will prevent a new empty row
                dataGridView1.AllowUserToAddRows = false;
            }
