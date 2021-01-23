    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public ObservableCollection<FrameworkElement> FirstCollection
        {
            get { return (ObservableCollection<FrameworkElement>)GetValue(FirstCollectionProperty); }
            set { SetValue(FirstCollectionProperty, value); }
        }
        // Using a DependencyProperty as the backing store for FirstCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FirstCollectionProperty =
            DependencyProperty.Register("FirstCollection", typeof(ObservableCollection<FrameworkElement>), typeof(UserControl1), new PropertyMetadata(new ObservableCollection<FrameworkElement>()));
        public ObservableCollection<FrameworkElement> SecondCollection
        {
            get { return (ObservableCollection<FrameworkElement>)GetValue(SecondCollectionProperty); }
            set { SetValue(SecondCollectionProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SecondCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondCollectionProperty =
            DependencyProperty.Register("SecondCollection", typeof(ObservableCollection<FrameworkElement>), typeof(UserControl1), new PropertyMetadata(new ObservableCollection<FrameworkElement>()));
        public ObservableCollection<FrameworkElement> LastCollection
        {
            get { return (ObservableCollection<FrameworkElement>)GetValue(LastCollectionProperty); }
            set { SetValue(LastCollectionProperty, value); }
        }
        // Using a DependencyProperty as the backing store for LastCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastCollectionProperty =
            DependencyProperty.Register("LastCollection", typeof(ObservableCollection<FrameworkElement>), typeof(UserControl1), new PropertyMetadata(new ObservableCollection<FrameworkElement>()));
    }
