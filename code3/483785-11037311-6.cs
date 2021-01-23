    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var data = new MyViewModel();
            int columnIndex = 0;
            foreach (var name in data.ColumnNames)
            {
                grid.Columns.Add(
                    new DataGridTextColumn
                    {
                        Header = name,
                        Binding = new Binding(
                            string.Format("Values[{0}]", columnIndex++))
                    });
            }
            DataContext = data;
        }
    }
    public class MyViewModel
    {
        public MyViewModel()
        {
            Items = new List<RowDataItem>
                {
                    new RowDataItem(),
                    new RowDataItem(),
                    new RowDataItem(),
                };
            ColumnNames = new List<string>{ "Col 1", "Col 2", "Col 3"};
        }
        public IList<string> ColumnNames { get; private set; }
        public IList<RowDataItem> Items { get; private set; }
    }
    public class RowDataItem
    {
        public RowDataItem()
        {
            Values = new List<string>{ "One", "Two", "Three"};    
        }
        public IList<string> Values { get; private set; }
    }
