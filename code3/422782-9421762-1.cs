    public partial class TrucksDisplay
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof (double), typeof (TrucksDisplay), new PropertyMetadata(DefaultValueChanged));
        private static void DefaultValueChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var trucksDisplay = (TrucksDisplay) dependencyObject;
            trucksDisplay.grid.Width = 40*trucksDisplay.Value;
        }
        public double Value
        {
            get { return (double) GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public TrucksDisplay()
        {
            InitializeComponent();
        }
    }
