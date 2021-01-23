    public partial class Window1 : Window
    {
        public ObservableCollection<string> Strings { get; set; }
        public List<string> StringsList
        {
            get { return (List<string>)GetValue(StringsListProperty); }
            set { SetValue(StringsListProperty, value); }
        }
        public static readonly DependencyProperty StringsListProperty =
            DependencyProperty.Register("StringsList", typeof(List<string>), typeof(Window), new PropertyMetadata(null, StringsListPropertyChanged));
        public Window1()
        {
            InitializeComponent();
            Strings = new ObservableCollection<string>();
            Strings.CollectionChanged += strings_CollectionChanged;
            StringsList = new List<string> { "Test1", "Test2", "Test3", "Test4" };
        }
        void strings_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //Fires everytime the observablecollection has an item added/removed etc.
            MessageBox.Show(string.Format("ObservableCollection has changed! Count is now {0}", this.Strings.Count.ToString()));
            if (this.Strings.Count == 10)
                Console.WriteLine("Collection contains 10 strings!!");
        }
        private static void StringsListPropertyChanged(DependencyObject e, DependencyPropertyChangedEventArgs args)
        {
            var newCount = ((List<string>)args.NewValue).Count.ToString();
            MessageBox.Show(string.Format("Dependency property has changed! Count is now {0}", newCount));
        }
        private void click1(object sender, RoutedEventArgs e)
        {
            this.Strings.Add("Test1");
        }
        private void click2(object sender, RoutedEventArgs e)
        {
            this.StringsList = new List<string> { "Newitem1", "Newitem2" };
        }
    }
