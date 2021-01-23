    private ObservableCollection<MyData> _data;
    
    public MainWindow()
    {
      InitializeComponent();
    
       _data = new ObservableCollection<MyData>()
                                            {
                                              new MyData() {City = "City1", Name = "Name1"},
                                              new MyData() {City = "City2", Name = "Name2"},
                                              new MyData() {City = "City3", Name = "Name3"},
                                            };
      MyListView.ItemsSource = _data;
    }
    
    public class MyData : INotifyPropertyChanged
    {
      private string _name;
      
      public string Name
      {
        get { return _name; }
        set { 
          _name = value;
          OnPropertyChanged("Name");
        }
      }
      
      private string _city;
    
      public string City
      {
        get { return _city; }
        set
        {
          _city = value;
          OnPropertyChanged("City");
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      public void OnPropertyChanged(string propertyName)
      {
        if (PropertyChanged != null)
        {
          PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      _data[1].City = "NewValue";
    }
