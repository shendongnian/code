        public Window1()
        {
            InitializeComponent();
            var dt = new DataTable();
            dt.Columns.Add("col1");
            dt.Columns.Add("col2");
            dt.Rows.Add("11", "12");
            dt.Rows.Add("21", "22");
            this.GridView1.DataContext = dt;
        }
