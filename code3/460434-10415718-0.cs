        private DataTable dataTable1;
        public Form1()
        {
            InitializeComponent();
            
            dataTable1 = new DataTable("myTable");
            dataTable1.Columns.Add("id", typeof (int));
            dataTable1.Columns.Add("name", typeof(string));
            dataTable1.Rows.Add(1, "Tomer");
            dataTable1.Rows.Add(2, "Ali");
            dataTable1.Rows.Add(3, "Some Other");
            listBox1.SelectedValueChanged += new EventHandler(listBox1_SelectedValueChanged);
            listBox1.DataSource = dataTable1; // collection of Rows
            listBox1.ValueMember = "id"; // what is the value of the row.
            listBox1.DisplayMember = "name"; // what should be visible to user
            listBox1.Refresh();
        }
        void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            label1.Text = string.Format("Selected: {0}", listBox1.SelectedValue);
        }
