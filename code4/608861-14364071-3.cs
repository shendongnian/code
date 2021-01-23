    public static readonly DependencyProperty SelectedTabProperty = DependencyProperty.Register("SelectedTab", typeof(TabItemHolder), typeof(MainWindow), new UIPropertyMetadata());
    public TabItemHolder SelectedTab
    {
        get { return (TabItemHolder)GetValue(SelectedTabProperty); }
        set
        {
            SetValue(SelectedTabProperty, value);
            NotifyPropertyChanged("SelectedTab");
        }
    }
    public static readonly DependencyProperty TabsProperty = DependencyProperty.Register("Tabs", typeof(ObservableCollection<TabItemHolder>), typeof(MainWindow), new UIPropertyMetadata());
    public ObservableCollection<TabItemHolder> Tabs
    {
        get { return (ObservableCollection<TabItemHolder>)GetValue(TabsProperty); }
        set
        {
            SetValue(TabsProperty, value);
            NotifyPropertyChanged("Tabs");
        }
    }
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        this.Tabs = new ObservableCollection<TabItemHolder>();
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        this.Tabs.Add(new TabItemHolder() { Header = "Hello, this is the new tab item!", Text = "Dummy text for the textbox" });
        this.SelectedTab = this.Tabs[this.Tabs.Count - 1];
    }
    public event PropertyChangedEventHandler PropertyChanged;
    public void NotifyPropertyChanged(String PropertyName)
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
    }
