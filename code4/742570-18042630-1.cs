    public partial class WindowEntryView
    {
        public static readonly DependencyProperty WindowViewModelProperty;
        public WindowViewModel WindowViewModel
        {
            get { return (WindowViewModel)GetValue(WindowViewModelProperty); }
            set
            {
                SetValue(WindowViewModelProperty, value);
                value.Refresh(); // I've putted this out of desperation to see if it would help.. it didn't.
            }
        }
        static WindowEntryView()
        {
            PropertyMetadata metadata = new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender); // Another attempt with no success.
            WindowViewModelProperty = DependencyProperty.Register("WindowViewModel", typeof(WindowViewModel), typeof(WindowEntryView), metadata);
        }
        public WindowEntryView()
        {
            //WindowViewModel = new WindowViewModel(19860522); This is the only attempt that made the label show something, but it didn't update later of course.
            InitializeComponent();
            WindowViewModel = new WpfApplication3.WindowViewModel() { Title = "Check" };
            DataContext = WindowViewModel;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowViewModel.Title = DateTime.Now.ToString();
        }
    }
