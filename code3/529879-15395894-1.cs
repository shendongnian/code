        async void messageBox(String msg)
        {
            MessageDialog dialog = new MessageDialog(msg,"Alert");
            await dialog.ShowAsync();
        }
       private void pButton_Clicked(object sender, RoutedEventArgs e)
        {
            PLPopup.IsOpen = false;
            String str = pInputBox.Text;
            hidePopup();
            messageBox(str);
        }
        void hidePopup()
        {
            pCanvas.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            pStackPanel.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            pText.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            pInputBox.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            pButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
        }
        void showPopup()
        {
            pCanvas.Visibility = Windows.UI.Xaml.Visibility.Visible;
            pStackPanel.Visibility = Windows.UI.Xaml.Visibility.Visible;
            pText.Visibility = Windows.UI.Xaml.Visibility.Visible;
            pInputBox.Visibility = Windows.UI.Xaml.Visibility.Visible;
            pButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
        }
        private void myPopup(object sender, RoutedEventArgs e)
        {
            Brush myBrush = new SolidColorBrush(Windows.UI.Colors.Black);
            topAppBar.IsOpen = false;
            bottomAppBar.IsOpen = false;
            myBrush.Opacity = .5;
            PLPopup = new Popup();
            PLPopup.IsOpen = true;
            //PLPopup.Child = myTextbox;
            pCanvas.Background = myBrush;
            pCanvas.Children.Add(PLPopup);
            pCanvas.Width = this.ActualWidth;
            pCanvas.Height = this.ActualHeight;
            showPopup();
        }
