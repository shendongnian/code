    public partial class SortedTreeView : Window
    {
        public SortedTreeViewWindowViewModel ViewModel { get { return DataContext as SortedTreeViewWindowViewModel; } set { DataContext = value; } }
        public SortedTreeView()
        {
            InitializeComponent();
            ViewModel = new SortedTreeViewWindowViewModel()
                {
                    Items = {new TreeViewModel(1)}
                };
        }
        private void AddNewItem(object sender, RoutedEventArgs e)
        {
            ViewModel.AddNewItem();
        }
        //Added due to limitation of TreeViewItem described in http://stackoverflow.com/questions/1000040/selecteditem-in-a-wpf-treeview
        private void OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ViewModel.SelectedItem = e.NewValue as TreeViewModel;
        }
    }
