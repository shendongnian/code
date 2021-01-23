        public MainWindow()
        {
            InitializeComponent();
            List<SimpleClass> ListData = new List<SimpleClass>();
            ListData.Add(new SimpleClass { Id = "1", Value = "One" });
            ListData.Add(new SimpleClass { Id = "2", Value = "Two" });
            ListData.Add(new SimpleClass { Id = "3", Value = "Three" });
            ListData.Add(new SimpleClass { Id = "4", Value = "Four" });
            ListData.Add(new SimpleClass { Id = "5", Value = "Five" });
            comboBox1.DataContext = ListData;
            comboBox1.DisplayMemberPath = "Value";
            comboBox1.SelectedValuePath = "Id";
        }
    public class SimpleClass
    {
        public string Id  { get; set; }
        public string Value { get; set; }
    }
