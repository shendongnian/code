    namespace WpfApplication8
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            #endregion
    
            public class Toto
            {
                public object Parent { get; set; }
    
                public string Name { get; set; }
                public string Content { get; set; }
    
                public Toto(string name, string content, object parent)
                {
                    this.Name = name; this.Content = content; this.Parent = parent;
                }
            }
    
            private object _mySelectedItem;
    
            public object MySelectedItem
            {
                get { return _mySelectedItem; }
                set
                {
                    _mySelectedItem = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new PropertyChangedEventArgs("MySelectedItem"));
                    }
                }
            }
    
            private List<Toto> _myObjectList;
    
            public List<Toto> MyObjectList
            {
                get { return _myObjectList; }
                set { _myObjectList = value; }
            }
    
            public MainWindow()
            {
                this.MyObjectList = new List<Toto>
                {
                    new Toto("toto1", "content toto1", this),
                    new Toto("toto2", "content toto2", this)
                };
    
                InitializeComponent();
    
                this.DataContext = this;
            }
        }
    }
