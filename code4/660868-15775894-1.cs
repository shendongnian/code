      public partial class DataGridAndDataTable : Window
        {
            public DataTable PluginSettings { get; set; }
    
            public DataGridAndDataTable()
            {
                InitializeComponent();
    
                PluginSettings = new DataTable();
                
                PluginSettings.Columns.Add("Name", typeof (string));
                PluginSettings.Columns.Add("Date", typeof(DateTime));
    
                PluginSettings.NewRow();
                PluginSettings.NewRow();
    
                PluginSettings.Rows.Add("Name01", DateTime.Now);
    
                DataContext = PluginSettings;
            }
    
            private void AddColumn(object sender, RoutedEventArgs e)
            {
                PluginSettings.Columns.Add("Age", typeof (int));
                DataContext = null;
                DataContext = PluginSettings;
            }
    
            private void AddRow(object sender, RoutedEventArgs e)
            {
                PluginSettings.Rows.Add("Name01", DateTime.Now);
            }
        }
