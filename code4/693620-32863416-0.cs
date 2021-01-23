            private void AlertMessage_Opened(object sender, object e)
        {
            UIBlock.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
        private void AlertMessage_Closed(object sender, object e)
        {
            UIBlock.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
