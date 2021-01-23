    class ExtRichTextBox : RichTextBox
    {
        public static DependencyProperty CurrentVerticalOffsetProperty =
            DependencyProperty.Register("CurrentVerticalOffset", typeof(double), typeof(ExtRichTextBox), new PropertyMetadata(new PropertyChangedCallback(OnVerticalChanged)));
        private static void OnVerticalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ExtRichTextBox extRtb = d as ExtRichTextBox;
            extRtb.ScrollToVerticalOffset((double)e.NewValue);
        }
        public double CurrentVerticalOffset
        {
            get { return (double)this.GetValue(CurrentVerticalOffsetProperty); }
            set { this.SetValue(CurrentVerticalOffsetProperty, value); }
        }
    }
