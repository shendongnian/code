         public ObservableCollection<string> Names { get; set; }
         public ICollectionView View { get; set; }
         public MainWindow()
         {
           InitializeComponent();
           Names= new ObservableCollection<string>();
           var viewSource  = new CollectionViewSource();
           viewSource.Source=Names;
          
          //Get the ICollectionView and set Filter
           View = viewSource.View;
 
          //Filter predicat, only items that start with "A"
           View.Filter = o => o.ToString().StartsWith("A");
           DataContext=this;
        }
