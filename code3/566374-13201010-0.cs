            public bool MyBoolProperty
            {
                get { return (bool)GetValue(MyBoolPropertyProperty); }
                set { SetValue(MyBoolPropertyProperty, value); }
            }
    
            /// <summary>
            /// Identifies the MyBoolProperty dependency property.
            /// </summary>
            public static readonly DependencyProperty MyBoolPropertyProperty =
                DependencyProperty.Register(
                    "MyBoolProperty",
                    typeof(bool),
                    typeof(MyClass),
                    new PropertyMetadata(false, OnMyBoolPropertyPropertyChanged));
    
            /// <summary>
            /// MyBoolPropertyProperty property changed handler.
            /// </summary>
            /// <param name="d">MyClass that changed its MyBoolProperty.</param>
            /// <param name="e">Event arguments.</param>
            private static void OnMyBoolPropertyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                MyClass source = d as MyClass; // Breakpoint here...
                bool value = (bool)e.NewValue;
            }
