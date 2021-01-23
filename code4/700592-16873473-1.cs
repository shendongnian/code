    public partial class MainWindow : Window
    {
        public ObservableCollection<NameItem> MyItems { get; set; }
        public MainWindow()
        {
            MyItems = new ObservableCollection<NameItem>();
            MyItems.Add(new NameItem() { Name = "A" });
            MyItems.Add(new NameItem() { Name = "B" });
            DataContext = this;
            InitializeComponent();
        }
        private void DataGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            foreach (var item in MyItems)
            {
                item.Selected = false;
            }
            var datagrid = sender as DataGrid;
            if (datagrid != null)
                foreach (var item in datagrid.SelectedItems)
                {
                    var nameItem = item as NameItem;
                    if (nameItem != null) nameItem.Selected = true;
                }
        }
    }
    public class NameItem : DependencyObject
    {
        public static readonly DependencyProperty SelectedProperty =
            DependencyProperty.Register("Selected", typeof (Boolean), typeof (NameItem), new PropertyMetadata(default(Boolean)));
        public Boolean Selected
        {
            get { return (Boolean) GetValue(SelectedProperty); }
            set { SetValue(SelectedProperty, value); }
        }
        public String Name { get; set; }
    }
