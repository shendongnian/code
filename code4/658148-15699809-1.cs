    public partial class MyItem : UserControl
    {
        #region ________________________________________  ItemBorderBrsuh
        public Brush ItemBorderBrsuh
        {
            get { return (Brush)GetValue(ItemBorderBrsuhProperty); }
            set { SetValue(ItemBorderBrsuhProperty, value); }
        }
        public static readonly DependencyProperty ItemBorderBrsuhProperty =
            DependencyProperty.Register("ItemBorderBrsuh",
                                        typeof(Brush),
                                        typeof(MyItem),
                                        new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Black), FrameworkPropertyMetadataOptions.None, OnItemBorderBrsuhPropertyChanged));
        private static void OnItemBorderBrsuhPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            MyItem instance = sender as MyItem;
            if (instance != null && e.NewValue is SolidColorBrush)
                instance.txtColorIndicator.Text = (e.NewValue as SolidColorBrush).Color.ToString();
        }
        #endregion
        public MyItem()
        {
            InitializeComponent();
            grdRoot.DataContext = this;
        }
    }
