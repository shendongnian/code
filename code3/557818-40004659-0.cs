        static MyControl()
        {
            // replace base implementation of the dependent property 
            FontSizeProperty.OverrideMetadata(typeof(Scalar), 
                new FrameworkPropertyMetadata(SystemFonts.MessageFontSize, FrameworkPropertyMetadataOptions.Inherits, OnMeasureInvalidated));
        }
        private static void OnMeasureInvalidated(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            // recurse over parent stack
            while (true)
            {
                var parent = VisualTreeHelper.GetParent(sender) as UIElement;
                if (parent == null) return; // break on root element
                parent.InvalidateMeasure();
                sender = parent;
            }
        }
