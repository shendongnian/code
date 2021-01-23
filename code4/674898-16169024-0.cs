            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                if (Listbox1.Items.Count > 0)
                {
                    if (dispatcherTimer.IsEnabled)
                        dispatcherTimer.Stop();
                    else
                    {
                        curImage = 0;
                        dispatcherTimer.Start();
                    }
                }
            }
    
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        Dispatcher.Invoke((Action)delegate
        {
            ShowNextImage();
        }, null);            
    }
    
    private void ShowNextImage()
    {
        if (curImage >= Listbox1.Items.Count)
            curImage = 0;
        var selected = Listbox1.Items[curImage];
        string s = selected.ToString();
        if (Listbox1Dict.ContainsKey(s))
        {
            mediaElement1.Visibility = Visibility.Visible;
            SearchBtn.Visibility = Visibility.Hidden;
            Listbox1.Visibility = Visibility.Hidden;
            FileNameTextBox.Visibility = Visibility.Hidden;
            mediaElement1.Source = new Uri(Listbox1Dict[s]);
            mediaElement1.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
            mediaElement1.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
            this.Background = new SolidColorBrush(Colors.Black);
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;
        }
    }
