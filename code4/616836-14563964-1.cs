    MessageBoxResult result = MessageBox.Show("Do you want to Load Selected items?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Information);
        if (result == MessageBoxResult.Yes)
        {
            imgSpin5.Visibility = Visibility.Visible;
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork((s,e)=>{
                foreach (CType ctp in dgAttributes.ItemsSource)
                {
                    if (ctp.IsSelected == true)
                    {
                        Dispatcher.Invoke(() =>
                        {
                            imgSpin5.Visibility = Visibility.Visible;
                        });
                    }
                }
            });
            backgroundWorker.RunWorkerAsync();
        }
