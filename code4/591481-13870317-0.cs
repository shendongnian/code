    public partial class MainWindow : Window, INotifyCollectionChanged
    {
    
        public event NotifyCollectionChangedEventHandler CollectionChanged;
    
        public MainWindow()
        {
            InitializeComponent();
        }
    
    
        public void NotifyCollectionChanged(NotifyCollectionChangedAction action)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(action));
            }
        }
    }
