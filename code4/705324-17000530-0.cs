        public static readonly DependencyProperty ValueAsyncProperty =
        DependencyProperty.RegisterAttached("ValueAsync", 
            typeof (double), 
            typeof (ProgressBarAttachedBehavior), 
    
            new UIPropertyMetadata(default(double),
    (o, e) => 
    Dispatcher.BeginInvoke( 
    new DependencyPropertyChangedEventHandler( ValueAsyncChanged), o, e);));
