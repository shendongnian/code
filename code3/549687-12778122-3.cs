    public Point Position
        {
            get { return (Point)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(Point), typeof(HorizontalRuler), new UIPropertyMetadata(defaultMousePoint,
              new PropertyChangedCallback(PositionPropertyChangedCallback)));
        private static void PositionPropertyChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            HorizontalRuler horizontalRuler = (HorizontalRuler)sender;
            horizontalRuler.InvalidateVisual();
        }
    
