        void _Loaded(object sender, RoutedEventArgs e)
        {
            DoSmthng();
        }
        void _Unloaded(object sender, RoutedEventArgs e)
        {
            DoSmthngElse();
        }
        
        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            DoSmthngOther();
            // Call base class to perform standard event handling. 
            base.OnVisualParentChanged(oldParent);
        }
