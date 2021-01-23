     public partial class MainWindow : Window
     {
       public ObservableCollection<string> fileList= new ObservableCollection<string>();
        public MainWindow()
        {
           InitializeComponent();
            this.DataContext = this;
           // Add files to fileList (ObservableCollection)  
        }
        public ObservableCollection<string> FileStore
       {
          get { return fileList; }
       } 
      }
