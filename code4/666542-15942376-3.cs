        private void txt1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var start =  TextBox1.SelectionStart;
            var length = TextBox1.SelectionLength;
            Dispatcher.RunIdleAsync((v) => Highlight());
        }
        public void Highlight()
        {
            TextBox2.Select(TextBox1.SelectionStart, TextBox1.SelectionLength);
        }
