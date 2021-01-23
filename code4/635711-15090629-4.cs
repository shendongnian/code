    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;
    
    namespace DummyTree
    {
        public partial class DataGridTest : Window
        {
            public DataGridTest()
            {
                DataContext = new CustomerVM();
                InitializeComponent();
            }
    
            private void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
            {
                var hyperlink = (Hyperlink)sender;
            Process.Start(hyperlink.NavigateUri.AbsoluteUri);
            e.Handled = true;
            }
        }
    
        public class CustomerVM
        {
            public ObservableCollection<Customer> Customers { get; set; }
            public CustomerVM()
            {
                Customers = new ObservableCollection<Customer> { new Customer { Name = "Leo" }, new Customer { Name = "Om" } };
            }
        }
    
        public class Customer
        {
            public string Name { get; set; }
        }
    }
