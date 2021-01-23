                    BackgroundWorker backgroundWorker = new BackgroundWorker();
                    backgroundWorker.DoWork += delegate(object s, DoWorkEventArgs args)
                    {
                        foreach (CoreDatumType ctp in dgAttributes.ItemsSource)
                        {
                            if (ctp.IsSelected == true)
                            {
                                Dispatcher.Invoke(() =>
                                {
                                    imgSpin.Visibility = Visibility.Visible;
                                });
                            }
                        }
                    };
                    backgroundWorker.RunWorkerAsync();
                    MessageBoxResult results = MessageBox.Show("Sucessfully Loaded..!", "Confirmation", MessageBoxButton.OK);
                    imgSpin.Visibility = Visibility.Hidden;
                }
