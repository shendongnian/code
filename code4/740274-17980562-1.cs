    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        this.MediaElement.Play();
        Task.Factory.StartNew(
            new Action(delegate()
            {
              /*
               * ------------------------------
                 Socket's Code Comes Here  |
                 ------------------------------
               */
              Dispatcher.Invoke(
                          new Action(delegate()
                          {
                                if (this.IsUpdateNeeded == true) //IsUpdateNeeded == My Own Variable..
                                {
                                           MessageBox.Show("New Version Is Here !", "New Version Is Here !", MessageBoxButton.OK, MessageBoxImage.Information);
                                           GoToWebsite();
                                }
                                else
                               {
                                   MessageBox.Show("You Own The Latest Version", "No Update Is Needed", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                               this.MediaElement.Stop();
                               this.Close();   
                          }                
                        ));
                    }
                )
            );
        }
