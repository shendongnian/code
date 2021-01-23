    public partial class UserControl1 : UserControl
    {
       public bool A
        {
            get { return (bool)GetValue(AProperty); }
            set { SetValue(AProperty, value); }
        }
        public static readonly DependencyProperty AProperty =
            DependencyProperty.Register("A", typeof(bool), typeof(UserControl1), new UIPropertyMetadata(false));
        public UserControl1()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
