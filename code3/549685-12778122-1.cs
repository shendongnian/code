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
            Point newValue = (Point)e.NewValue;
            Point oldValue = (Point)e.OldValue;
            horizontalRuler.OnPositionChanged(oldValue, newValue);
        }
        private void OnPositionChanged(Point oldValue, Point newValue)
        {
            RoutedPropertyChangedEventArgs<Point> args = new RoutedPropertyChangedEventArgs<Point>(oldValue, newValue);
            args.RoutedEvent = HorizontalRuler.PositionChangedEvent;
            RaiseEvent(args);
            InvalidateVisual();
        }
        public static readonly RoutedEvent PositionChangedEvent =
           EventManager.RegisterRoutedEvent("PositionChanged", RoutingStrategy.Bubble,
               typeof(RoutedPropertyChangedEventHandler<Point>), typeof(HorizontalRuler));
        public event RoutedPropertyChangedEventHandler<Point> PositionChanged
        {
            add { AddHandler(PositionChangedEvent, value); }
            remove { RemoveHandler(PositionChangedEvent, value); }
        }
