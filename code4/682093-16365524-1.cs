    using System.Collections.ObjectModel;
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public ObservableCollection<int> Values { get; set; }
        public Window1()
        {
            InitializeComponent();
            Values = new ObservableCollection<int>();
            Values.Add(1);
            DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Values.Add(2);
        }
    }
