            public string ButtonContent
            {
                get { return (string)GetValue(ButtonContentProperty); }
                set { SetValue(ButtonContentProperty, value); }
            }
                    
            public static readonly DependencyProperty ButtonContentProperty =
                DependencyProperty.Register("ButtonContent", typeof(string), typeof(UserControl1), new UIPropertyMetadata(string.Empty));
                         
            public RoutedCommand ClickHereCommand
            {
                get { return (RoutedCommand)GetValue(ClickHereCommandProperty); }
                set { SetValue(ClickHereCommandProperty, value); }
            }
                    
            public static readonly DependencyProperty ClickHereCommandProperty =
                DependencyProperty.Register("ClickHereCommand", typeof(RoutedCommand), typeof(UserControl1), new UIPropertyMetadata(null));
