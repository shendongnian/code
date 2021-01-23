    namespace WpfApplication17
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private List<string> _selectedItems = new List<string>();
            private ObservableCollection<string> _items = new ObservableCollection<string> 
            { "Orange", "Mango", "Stawberry", "Pineapple", "Apple", "Grape", "Banana" };
          
            public MainWindow()
            {
                InitializeComponent();
            }
        
            public ObservableCollection<string> Items
            {
                get { return _items; }
                set { _items = value; }
            }
    
            public List<string> SelectedItems
            {
                get { return _selectedItems; }
                set { _selectedItems = value; OnPropertyChanged("SelectedItems"); }
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                SelectedItems = new List<string> { "Orange", "Pineapple", "Apple" };
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string e)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(e));
            }
        }
    
        public static class ListBoxExtensions
        {
            // Using a DependencyProperty as the backing store for SearchValue.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty SelectedItemListProperty =
                DependencyProperty.RegisterAttached("SelectedItemList", typeof(IList), typeof(ListBoxExtensions),
                    new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnSelectedItemListChanged)));
    
            public static IList GetSelectedItemList(DependencyObject obj)
            {
                return (IList)obj.GetValue(SelectedItemListProperty);
            }
    
            public static void SetSelectedItemList(DependencyObject obj, IList value)
            {
                obj.SetValue(SelectedItemListProperty, value);
            }
    
            private static void OnSelectedItemListChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var listbox = d as ListBox;
                if (listbox != null)
                {
                    listbox.SelectedItems.Clear();
                    var selectedItems = e.NewValue as IList;
                    if (selectedItems != null)
                    {
                        foreach (var item in selectedItems)
                        {
                            listbox.SelectedItems.Add(item);
                        }
                    }
                }
            }
        }
    }
