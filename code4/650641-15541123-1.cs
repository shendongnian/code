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
    
                _myCollection = new ObservableCollection<MyListBoxItem>() { new MyListBoxItem("Orange"), new MyListBoxItem("Mango"), new MyListBoxItem("Stawberry"), new MyListBoxItem("Pineapple") };
    
                //Items to be selected on this.MyCollection ListBox
                this.SubCollection = new List<string>() { "Pineapple", "Mango" };
    
                this.DataContext = this;
            }
            
            private ObservableCollection<MyListBoxItem> _myCollection;
            public ObservableCollection<MyListBoxItem> MyCollection
            {
                get { return _myCollection; }
                set
                {
                    this._myCollection = value;
                }
            }
    
            public IList<string> SubCollection { get; set; }
            
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                // Clear all the selected items in the ListBox
                this.MyCollection.ToList().ForEach(item => item.IsSelected = false);
                
                // SELECT only the items in MySubCollection into this.MyCollection ListBox
                this.MyCollection.Where(item => this.SubCollection.Contains(item.Content.ToString())).ToList().ForEach(item => item.IsSelected= true);
            }
        }
    
        public class MyListBoxItem : ListBoxItem
        {
            public MyListBoxItem(string displayName)
            {
                this.Content = displayName;
            }
        }
    }
