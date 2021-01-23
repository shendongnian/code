    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Entry> MyCollection {get;set;}
        public MainWindow()
        {
            InitializeComponent();
            MyCollection = new ObservableCollection<Entry>();
            MyCollection.Add(new Entry() { Name = "Test" });
            MyCollection.Add(new Entry() { Name = "ABCD" });
            MyCollection.Add(new Entry() { Name = "TESTABC" });
            MyCollection.Add(new Entry() { Name = "BCDtest" });
            this.MyListView.DataContext = this;
        }
        private void searchTerm_KeyUp(object sender, KeyEventArgs e)
        {
            String term = ((TextBox)sender).Text;
    
            foreach (Entry entry in this.MyCollection)
            {
                if (entry.Name.Contains(term))
                    entry.Highlight();
                else
                    entry.UnHighlight();
            }
        }
    }
    public class Entry : INotifyPropertyChanged
    {
        public String Name { get; set; }
        public Color BGColor { get; set; }
        public SolidColorBrush BGBrush
        {
            get
            {
                return new SolidColorBrush(this.BGColor);
            }
        }
        public Entry()
        {
            this.UnHighlight();
        }
        public void Highlight()
        {
            this.BGColor = Colors.Yellow;
            this.NotifyPropertyChanged("BGBrush");
        }
        public void UnHighlight()
        {
            this.BGColor = Colors.White;
            this.NotifyPropertyChanged("BGBrush");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
