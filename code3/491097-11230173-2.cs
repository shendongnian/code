        public Form1()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("a");
            dt.Rows.Add(123.4);
            dt.Rows.Add(123.45);
            dt.Rows.Add(123.456);
            dt.Rows.Add(123.4567);
            dt.Rows.Add(123.45678);
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }
        void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != this.dataGridView1.NewRowIndex)
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("0.00##");
            }
        } 
