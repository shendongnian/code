    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public ObservableCollection<object> FirstCollection
        {
            get { return (ObservableCollection<object>)GetValue(FirstCollectionProperty); }
            set { SetValue(FirstCollectionProperty, value); }
        }
        // Using a DependencyProperty as the backing store for FirstCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FirstCollectionProperty =
            DependencyProperty.Register("FirstCollection", typeof(ObservableCollection<object>), typeof(UserControl1), new PropertyMetadata(new ObservableCollection<object>()));
        public ObservableCollection<object> SecondCollection
        {
            get { return (ObservableCollection<object>)GetValue(SecondCollectionProperty); }
            set { SetValue(SecondCollectionProperty, value); }
        }
        // Using a DependencyProperty as the backing store for SecondCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondCollectionProperty =
            DependencyProperty.Register("SecondCollection", typeof(ObservableCollection<object>), typeof(UserControl1), new PropertyMetadata(new ObservableCollection<object>()));
        public ObservableCollection<object> LastCollection
        {
            get { return (ObservableCollection<object>)GetValue(LastCollectionProperty); }
            set { SetValue(LastCollectionProperty, value); }
        }
        // Using a DependencyProperty as the backing store for LastCollection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastCollectionProperty =
            DependencyProperty.Register("LastCollection", typeof(ObservableCollection<object>), typeof(UserControl1), new PropertyMetadata(new ObservableCollection<object>()));
    }
