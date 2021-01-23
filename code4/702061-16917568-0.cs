    public MainPage()
            {
                this.InitializeComponent();
                this.controlsDataSource = new ObservableCollection<AllControls.Models.Control>();
                this.controlsDataSource.Add(new AllControls.Models.Control("ScrollViewer", "ScrollViewer Desc"));
                this.controlsDataSource.Add(new AllControls.Models.Control("ScrollViewer", "ScrollViewer Desc"));
                this.controlsDataSource.Add(new AllControls.Models.Control("ScrollViewer", "ScrollViewer Desc"));
                listOfControls.DataContext = controlsDataSource;      
      }
   
