    using System.Collections.Generic;
    using System.Windows;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new ViewModel();
            }
        }
    
        public class ViewModel
        {
            public ColumnConfig ColumnConfig { get; set; }
            public IEnumerable<Product> Products { get; set; }
    
            public ViewModel()
            {
                Products = new List<Product> { new Product { Name = "Some product", Attributes = "Very cool product" }, new Product { Name = "Other product", Attributes = "Not so cool one" } };
                ColumnConfig = new ColumnConfig { Columns = new List<Column> { new Column { Header = "Name", DataField = "Name" }, new Column { Header = "Attributes", DataField = "Attributes" } } };
            }
        }
    
        public class ColumnConfig
        {
            public IEnumerable<Column> Columns { get; set; }
        }
    
        public class Column
        {
            public string Header { get; set; }
            public string DataField { get; set; }
        }
    
        public class Product
        {
            public string Name { get; set; }
            public string Attributes { get; set; }
        }
    }
