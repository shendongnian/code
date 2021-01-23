    namespace WpfApplication
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                ResourceData data = GetData();
                _dataGrid.ItemsSource = data;
    
                for (int i = 0; i < data[0].ResourceStringList.Count; i++)
                {
                    DataGridTextColumn column = new DataGridTextColumn();
                    column.Binding = new Binding(string.Format("ResourceStringList[{0}]", i));
                    column.Header = string.Format("dynamic column {0}", i);
                    _dataGrid.Columns.Add(column);
                }
            }
    
            public ResourceData GetData()
            {
                List<ResourceRow> rows = new List<ResourceRow>();
    
                for (int i = 0; i < 5; i++)
                {
                    rows.Add(new ResourceRow() { KeyIndex = i.ToString(), FileName = string.Format("File {0}", i), ResourceName = string.Format("Name {0}", i), ResourceStringList = new List<string>() { "first", "second", "third" } });
                }
                return new ResourceData(rows);
            }
        }
    
        public class ResourceData : ObservableCollection<ResourceRow>
        {
            public ResourceData(List<ResourceRow> resourceRowList)
                : base()
            {
                foreach (ResourceRow row in resourceRowList)
                    Add(row);
            }
        }
    
        public class ResourceRow
        {
            private string keyIndex;
            private string fileName;
            private string resourceName;
            private List<string> resourceStringList;
    
            public string KeyIndex
            {
                get { return keyIndex; }
                set { keyIndex = value; }
            }
    
            public string FileName
            {
                get { return fileName; }
                set { fileName = value; }
            }
    
            public string ResourceName
            {
                get { return resourceName; }
                set { resourceName = value; }
            }
    
            public List<string> ResourceStringList
            {
                get { return resourceStringList; }
                set { resourceStringList = value; }
            }
        }
    }
