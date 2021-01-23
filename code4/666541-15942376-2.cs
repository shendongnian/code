        private void txt1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var start =  TextBox1.SelectionStart;
            var length = TextBox1.SelectionLength;
            Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Low, 
                () => TextBox2.Select(start, length));
        }
