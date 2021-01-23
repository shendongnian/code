     public MainWindow()
        {
            InitializeComponent();
            var col = new DataGridTextColumn();
            col.Header = "Column1";
            col.Binding = new Binding("[0]");
            dataGrid1.Columns.Add(col);
            col = new DataGridTextColumn();
            col.Header = "Column2";
            col.Binding = new Binding("[1]");
            dataGrid1.Columns.Add(col);
            
            col = new DataGridTextColumn();
            col.Header = "Column3";
            col.Binding = new Binding("[2]");
            dataGrid1.Columns.Add(col);
            
            //dataGrid1.ad
            
            List<object> rows = new List<object>();
            string[] value;
            value = new string[3];
            value[0] = "hello";
            value[1] = "world";
            value[2] = "the end";
            rows.Add(value);
            dataGrid1.ItemsSource = rows;
        }
