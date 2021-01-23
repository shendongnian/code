    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<DataObject> Collection { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        #region Private Methods
        public MainWindow()
        {
            
            InitializeComponent();
            Collection = new ObservableCollection<DataObject>();
            Collection.Add(new DataObject { Name = "item1" });
            Collection.Add(new DataObject { Name = "item2" });
            Collection.Add(new DataObject { Name = "item3" });
            Collection.Add(new DataObject { Name = "item4" });
            Collection.Add(new DataObject { Name = "item5" });
            this.DataContext = this;
        }
        #endregion
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            DataObject data = chk.DataContext as DataObject;
            string combinedText = string.Empty;
            foreach (var item in this.Collection)
            {
                if (item.IsChecked.HasValue && item.IsChecked.Value)
                {
                    if (combinedText == string.Empty)
                        combinedText = item.Name;
                    else
                        combinedText += ", " + item.Name;
                }
            }
            CboText = combinedText;
        }
        private string _cboCombinedText = "" ;
        public string CboText 
        {
            get 
            { 
                return this._cboCombinedText; }
            set
            {
                this._cboCombinedText = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CboText"));
            }
        }
        public class DataObject 
        {
            private bool? _isChecked = false;
            public string Name { get; set; }
            public bool? IsChecked { get { return _isChecked; } set { _isChecked = value; } }
        }
    }
