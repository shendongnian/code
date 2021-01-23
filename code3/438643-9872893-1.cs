    public partial class ItemsSelectionLists : UserControl
     {
        #region properties
        public string LeftHeader
        {
            get
            {
                return (string) GetValue(LeftHeaderProperty);
            }
            set
            {
                SetValue(LeftHeaderProperty, value);
            }
        }
        // Using a DependencyProperty as the backing store for LeftHeader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeftHeaderProperty =
            DependencyProperty.Register("LeftHeader", typeof(string), typeof(ItemsSelectionLists), new UIPropertyMetadata("Left List Header"));
        public string RightHeader
        {
            get
            {
                return (string) GetValue(RightHeaderProperty);
            }
            set
            {
                SetValue(RightHeaderProperty, value);
            }
        }
        // Using a DependencyProperty as the backing store for RightHeader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RightHeaderProperty =
            DependencyProperty.Register("RightHeader", typeof(string), typeof(ItemsSelectionLists), new UIPropertyMetadata("Right List Header"));
        private object dataSource;
        public object DataSource
        {
            get
            {
                return dataSource;
            }
            set
            {
                if (!value.GetType().FullName.StartsWith("TimeTracker.ViewModel"))
                    throw new ArgumentException("DataSource is not an instance of ViewModel");
                if (dataSource != value)
                {
                    dataSource = value;
                    this.DataContext = this.DataSource;
                    DataTemplateSelector templateSelector = dataSource as DataTemplateSelector;
                    this.LeftItemsList.ItemTemplateSelector = templateSelector;
                    this.RightItemsList.ItemTemplateSelector = templateSelector;
                }
            }
        }
        #endregion
        public ItemsSelectionLists()
            : base()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var type = dataSource.GetType();
            var MoveItems = type.GetMethod("MoveItems");
            var MoveAllItems = type.GetMethod("MoveAllItems");
            switch (button.Content.ToString())
            {
                case ">":
                MoveItems.Invoke(dataSource, new object[] { LeftItemsList, true });
                break;
                case ">>":
                MoveAllItems.Invoke(dataSource, new object[] { true });
                break;
                case "<":
                MoveItems.Invoke(dataSource, new object[] { RightItemsList, false });
                break;
                case "<<":
                MoveAllItems.Invoke(dataSource, new object[] { false });
                break;
            }
        }
    }
