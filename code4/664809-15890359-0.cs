    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
            var folderData = new Dictionary<string, object>();
            folderData.Add("some test", "A brand new folder was created");
            LiveConnectClient liveClient = new LiveConnectClient(mySession);
            liveClient.PostAsync("me/skydrive", folderData)
                      .ContinueWith((t) => 
                                     { 
                                        if (t.IsFauled)
                                        {
                                           MessageBox.Show("Error creating folder: " + t.Exception.Message);
                                        }
                                        else
                                        {
                                            MessageBox.Show("uploded");  
                                        }
                                     }
                                    , TaskScheduler.FromCurrentSynchronizationContext());
        
    }
