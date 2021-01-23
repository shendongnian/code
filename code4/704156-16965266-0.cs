    public class IndexedRadioButton : RadioButton
    {
        public static readonly DependencyProperty IndexProperty = DependencyProperty.Register(
            "Index",
            typeof(int),
            typeof(IndexedRadioButton),
            null);
        public int Index
        {
            get { return (int)GetValue(IndexProperty); }
            set { SetValue(IndexProperty, value); }
        }
    }
