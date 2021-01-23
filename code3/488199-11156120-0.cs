    Task.Factory.StartNew(() =>
                                  {
                                      var users = VkontakteApi.GetUsers(uids, Field.Online);
                                      foreach(var user in users)
                                      {
                                          richTextBox1.Text += string.Format("ID:{0} online:{1}", user.uid,
                                                                             user.online);
                                      }
                                  }, CancellationToken.None,
                                     TaskScheduler.FromCurrentSynchronizationContext());
