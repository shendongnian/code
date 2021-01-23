    public partial class MyUserControl : UserControl
    {
        public static DependencyProperty TextBlockStyleProperty =
            DependencyProperty.Register("TextBlockStyle",
                                        typeof(Style),
                                        typeof(MyUserControl));
        public MyUserControl()
        {
            InitializeComponent();
        }
        public Style TextBlockStyle
        {
            get { return (Style)GetValue(TextBlockStyleProperty); }
            set { SetValue(TextBlockStyleProperty, value); }
        }
    }
