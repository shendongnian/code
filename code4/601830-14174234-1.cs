    public class TimeCursor : FrameworkElement
    {
        public static readonly DependencyProperty LocationProperty =
            DependencyProperty.Register(
                "Location", typeof(double), typeof(TimeCursor),
                new FrameworkPropertyMetadata(LocationPropertyChanged)); // register callback here
        public double Location
        {
            get { return (double)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }
        private static void LocationPropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var timeCursor = obj as TimeCursor;
            // handle Location property changes here
            ...
        }
    }
