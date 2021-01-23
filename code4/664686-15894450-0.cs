    public partial class ItemsList : UserControl
    {
        public ItemsList()
        {
            InitializeComponent();
        }
        public IEnumerable Items
        {
        get { return (IEnumerable)GetValue(ItemsProperty); }
        set { SetValue(ItemsProperty, value); }
        }
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(IEnumerable), typeof(ItemsList), new PropertyMetadata(ItemsChanged));
        private static void ItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var controll = (ItemsList)d;
            var val = (IEnumerable)e.NewValue;
            controll.lls.ItemSource = val;
        }
