     public Form1()
        {
            InitializeComponent();
            Random r = new Random();
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("ImageName", typeof(string));
            table.Rows.Add(1, "Row 1", "copy.png");
            table.Rows.Add(2, "Row 2", "cut.png");
            table.Rows.Add(3, "Row 3", "folder.png");
            table.Rows.Add(4, "Row 4", "help.png");
            this.radGridView1.DataSource = table;
            radGridView1.Columns["ImageName"].IsVisible = false;
            GridViewImageColumn col = new GridViewImageColumn("Image");
            radGridView1.Columns.Add(col);
            foreach (GridViewRowInfo row in radGridView1.Rows)
            {
                string path = "..\\..\\"; //here you set your path
                row.Cells["Image"].Value = Image.FromFile( Path.Combine(path, row.Cells["ImageName"].Value.ToString()));
                
            }
        }
