        public static readonly DependencyProperty HighlightedProperty = DependencyProperty.Register("highlightedIndex", typeof(int), typeof(MyListView), new PropertyMetadata(null, propertyChanged));
        private static void propertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            int newValue = (int)e.NewValue;
            ListView lv = (ListView)d;
            foreach (ListViewItem lvi in lv.Items)
            {
                if (lv.Items.IndexOf(lvi) == newValue)
                {
                    lvi.Background = new SolidColorBrush(Colors.LightGreen);
                }
                else
                {
                    lvi.Background = new SolidColorBrush();
                }
            }
        }
