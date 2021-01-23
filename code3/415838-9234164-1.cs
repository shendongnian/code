    public partial class CmpTextView : UserControl
    {
        public CmpTextView()
        {
            InitializeComponent();
        }
        private static readonly DependencyPropertyKey IsEqualPropertyKey = DependencyProperty.RegisterReadOnly("IsEqual", typeof(bool), typeof(CmpTextView), new FrameworkPropertyMetadata(null, CoerceIsEqual));
        public static readonly DependencyProperty IsEqualProperty = IsEqualPropertyKey.DependencyProperty;
        public bool IsEqual
        {
            get { return (bool)GetValue(IsEqualProperty); }
        }
        private static object CoerceIsEqual(DependencyObject d, object baseValue)
        {
            CmpTextView cmpTextView = (CmpTextView) d;
            return cmpTextView.Text1 == cmpTextView.Text2;
        }
        public static readonly DependencyProperty Text1Property = DependencyProperty.Register("Text1", typeof(String), typeof(CmpTextView), new FrameworkPropertyMetadata(OnTextChanged));
        public string Text1
        {
            get { return (string)GetValue(Text1Property); }
            set { SetValue(Text1Property, value); }
        }
        public static readonly DependencyProperty Text2Property = DependencyProperty.Register("Text2", typeof(String), typeof(CmpTextView), new FrameworkPropertyMetadata(OnTextChanged));
        public string Text2
        {
            get { return (string)GetValue(Text2Property); }
            set { SetValue(Text2Property, value); }
        }
        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.CoerceValue(IsEqualProperty);
        }
    }
