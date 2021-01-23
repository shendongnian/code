    class DoubleClickBehavior : Behavior<TextBox>
        {
            protected override void OnAttached()
            {
                AssociatedObject.MouseDoubleClick += AssociatedObjectMouseDoubleClick;
                base.OnAttached();
            }
    
            protected override void OnDetaching()
            {
                AssociatedObject.MouseDoubleClick -= AssociatedObjectMouseDoubleClick;
                base.OnDetaching();
            }
    
            private void AssociatedObjectMouseDoubleClick(object sender, RoutedEventArgs routedEventArgs)
            {
                AssociatedObject.SelectAll();
            }
        }
