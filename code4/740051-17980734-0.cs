        public static readonly RoutedEvent ReloadClickEvent = EventManager.RegisterRoutedEvent("ReloadClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(BorderEx));
        public event RoutedEventHandler ReloadClick
        {
            add { AddHandler(ReloadClickEvent, value); }
            remove { RemoveHandler(ReloadClickEvent, value); }
        }
        static BorderEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BorderEx), new FrameworkPropertyMetadata(typeof(BorderEx)));
        }
