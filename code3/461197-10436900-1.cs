    #region Background
            public const string BackgroundPropertyName = "Background";
            public new Brush Background
            {
                get { return (Background)GetValue (BackgroundProperty); }
                set { SetValue (Background, value); }
            }
            public static new readonly DependencyProperty BackgroundProperty = DependencyProperty.Register (
                BackgroundPropertyName,
                typeof (Brush),
                typeof (Tile),
                new PropertyMetadata (BackgroundChanged));
    
            static void BackgroundChanged (DependencyObject d, DependencyPropertyChangedEventArgs e)
            {                
                ((Tile) d).rectBackground = (Brush)e.NewValue;    
            }
        #endregion
