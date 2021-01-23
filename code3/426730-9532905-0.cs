    public class MyScrollViewer : ScrollViewer
    {
        public static readonly DependencyProperty MyOffsetProperty = DependencyProperty.Register(
            "MyOffset", typeof(double), typeof(MyScrollViewer),
            new PropertyMetadata(new PropertyChangedCallback(onChanged)));
    
        public double MyOffset
        {
            get { return (double)this.GetValue(ScrollViewer.VerticalOffsetProperty); }
            set { this.ScrollToVerticalOffset(value); }
        }
        private static void onChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MyScrollViewer)d).MyOffset = (double)e.NewValue;
        }
    }
