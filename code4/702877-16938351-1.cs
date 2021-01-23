        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var source = this.Resources["source"] as CollectionViewSource;
            source.Filter += source_Filter;
        }
        private void source_Filter(object sender, FilterEventArgs e)
        {
            if (((TableRecord) e.Item).State == RecordState.Deleted)
            {
                e.Accepted = false;
            }
            else
            {
                e.Accepted = true;
            }
        }
