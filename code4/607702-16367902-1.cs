    public partial class MainWindow : Window{
      public ObservableCollection<int> Items { get; private set; }
      //lock object for synchronization;
      private static object _syncLock = new object();
      public MainWindow()
      {
        InitializeComponent();
        Items = new ObservableCollection<int>();
        //Enable the cross acces to this collection elsewhere
        BindingOperations.EnableCollectionSynchronization(Items, _syncLock);
        DataContext = this;
        Loaded += MainWindow_Loaded;
      }
      void MainWindow_Loaded(object sender, RoutedEventArgs e)
      {
            Task.Factory.StartNew(() =>
            {
                foreach (var item in Enumerable.Range(1, 500))
                {
                    lock(_syncLock) {
                      Items.Add(item);
                    }
                }
            });                
      }
    }
