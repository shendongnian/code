    public partial class PageHeaderControl : UserControl
    {
        public static readonly DependencyProperty HeaderProperty =
                DependencyProperty.Register("Header", typeof(string), typeof(PageHeaderControl), new PropertyMetadata(""));
        public string Header
        {
            get
            {
                return GetValue(HeaderProperty) as string;
            }
            set
            {
                SetValue(HeaderProperty, value);
            }
        }
        public PageHeaderControl()
        {
            InitializeComponent();
        }
    }
