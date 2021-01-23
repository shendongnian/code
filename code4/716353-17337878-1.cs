    public class TestDataForImage : DependencyObject
    {
        public string NotFoundString
        {
            get
            {
                return (string)GetValue(NotFoundStringProperty);
            }
            set
            {
                SetValue(NotFoundStringProperty, value);
            }
        }
        public static readonly DependencyProperty NotFoundStringProperty = DependencyProperty.Register("NotFoundString", typeof(string), typeof(TestDataForImage), new PropertyMetadata(""));
        public string NullString
        {
            get
            {
                return (string)GetValue(NullStringProperty);
            }
            set
            {
                SetValue(NullStringProperty, value);
            }
        }
        public static readonly DependencyProperty NullStringProperty = DependencyProperty.Register("NullString", typeof(string), typeof(TestDataForImage), new PropertyMetadata(""));
        public TestDataForImage()
        {
            NotFoundString = "pack://application:,,,/NotExistingImage.png";
            NullString = null;
        }
    }
