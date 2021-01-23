        public string HighlightSource
        {
            get { return (string)GetValue(HighlightSourceProperty); }
            set { SetValue(HighlightSourceProperty, value); }
        }
        
        public static readonly DependencyProperty HighlightSourceProperty =
            DependencyProperty.Register("HighlightSource", typeof(string), typeof(HighlightableTextBlock), new PropertyMetadata("", OnChange));
