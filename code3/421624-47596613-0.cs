    public Window1()
    {
       InitializeComponent();
       DataContext = this;
    
       // Need to initialize this, otherwise you get a null exception
       MyListViewBinding = new ObservableCollection<string>();
    }
    public ObservableCollection<string> MyListViewBinding { get; set; }
    
    // Add an item to the list        
    private void Button_Click_Add(object sender, RoutedEventArgs e)
    {
       // Custom control for entering a single string
       SingleEntryDialog _Dlg = new SingleEntryDialog();
       // OutputBox is a string property of the custom control
       if ((bool)_Dlg.ShowDialog())
          MyListViewBinding.Add(_Dlg.OutputBox.Trim());
    }
