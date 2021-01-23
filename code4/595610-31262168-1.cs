        /// <summary>The attached dependency property.</summary>
        public static readonly DependencyProperty AutoScrollToEndProperty =
            DependencyProperty.RegisterAttached("AutoScrollToEnd", typeof(bool), typeof(TextBoxBehavior),
                new UIPropertyMetadata(false, AutoScrollToEndPropertyChanged));
        /// <summary>Gets the value.</summary>
        /// <param name="obj">The object.</param>
        /// <returns>The value.</returns>
        public static bool GetAutoScrollToEnd(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollToEndProperty);
        }
        /// <summary>Enables automatic scrolling behavior, unless the <c>TextBox</c> has focus.</summary>
        /// <param name="obj">The object.</param>
        /// <param name="value">The value.</param>
        public static void SetAutoScrollToEnd(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollToEndProperty, value);
        }
        private static void AutoScrollToEndPropertyChanged(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs e)
        {
            var textBox = dependencyObject as TextBox;
            var newValue = (bool)e.NewValue;
            if (textBox == null || (bool)e.OldValue == newValue)
            {
                return;
            }
            if (newValue)
            {
                textBox.TextChanged += AutoScrollToEnd_TextChanged;
            }
            else
            {
                textBox.TextChanged -= AutoScrollToEnd_TextChanged;
            }
        }
        private static void AutoScrollToEnd_TextChanged(object sender, TextChangedEventArgs args)
        {
            var tb = (TextBox)sender;
            if (tb.IsFocused)
            {
                return;
            }
            if (tb.LineCount > 1) // scroll to bottom
            {
                tb.ScrollToEnd();
            }
            else // scroll horizontally (what about FlowDirection ??)
            {
                tb.Dispatcher.BeginInvoke(new Action(() => tb.ScrollToHorizontalOffset(1000.0)), DispatcherPriority.Input);
            }
        }
