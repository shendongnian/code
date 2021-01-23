        public partial class Window1 : Window, INotifyPropertyChanged
    {
        private Model model;
    
        public Model ModelData
        {
            get { return model; }
            set
            {
                model = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ModelData"));
            }
        }
    
        public Window1()
        {
            this.InitializeComponent();
                ModelData = new Model();          
            MyGrid.ItemsSource = ModelData.Content;
          
        }
      
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class Model
    {
        public ObservableCollection<Single> Content { get; set; }
    
        private Random r;
    
        private static object _syncLock = new object();
    
        public Model()
        {
            Content = new ObservableCollection<Single>();
            Content.Add(new Single { Name = "name" });
            r = new Random();
    
            // BindingOperations.EnableCollectionSynchronization(Content, _syncLock);
            DispatcherTimer t = new DispatcherTimer();
            t.Interval = new TimeSpan(2000);
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }
    
        void t_Tick(object sender, EventArgs e)
        {
            App.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (Content.Count <= 100)
                    Content.Add(new Single { Name = "name" });
                Content[r.Next(0, Content.Count())].Name = "rename" + r.Next(1, 100);
    
            }));
        }
    
    
    }
    public class Single : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
