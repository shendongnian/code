    <ComboBox ItemsSource="{Binding Path=MyCollection}"
              SelectedValue="{Binding Path=MySelectedString}"
              SelectedValuePath="StringProp" />
    public class CustomComboBoxItem : ComboBoxItem
    {
        // Not sure what the property name is...
        public string StringProp { get; set; }
        ...
    }
    // I'm assuming you don't have a separate ViewModel class and you're using
    // the actual window/page as your ViewModel (which you shouldn't do...)
    public class MyWPFWindow : Window, INotifyPropertyChanged
    {
        public MyWPFWindow()
        {
            MyCollection = new ObservableCollection<CustomComboBoxItem>();
            // Add values somewhere in code, doesn't have to be here...            
            MyCollection.Add(new CustomComboBoxItem("Text Box", "0"));
            etc ... 
            InitializeComponent();
        }
        public ObservableCollection<CustomComboBoxItem> MyCollection
        {
            get;
            private set;
        }
        private string _mySelectedString;
        public string MySelectedString
        {
            get { return _mySelectedString; }
            set
            {
                if (String.Equals(value, _mySelectedString)) return;
                _mySelectedString = value;
                RaisePropertyChanged("MySelectedString");
            }
        }
        public void GetStringFromDb()
        {
            // ...
            MySelectedString = dtDataList.Rows[0]["ControlList"].ToString().Trim();
        }
    }
