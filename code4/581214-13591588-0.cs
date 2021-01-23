    public partial class Window1 : Window
    {
        public ObservableCollection<string> strings { get; set; }
        public Window1()
        {
            InitializeComponent();
            strings = new ObservableCollection<string>();
            strings.CollectionChanged += strings_CollectionChanged;
        }
        void strings_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //Fires everytime the observablecollection has an item added/removed etc.
            if (this.strings.Count == 10)
                Console.WriteLine("Collection contains 10 strings!!");
        }
    }
