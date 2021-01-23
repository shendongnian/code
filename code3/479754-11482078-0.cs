    lstbox.Dispatcher.BeginInvoke(() =>
                    {
                        lstbox.ItemsSource = null;
                        lstbox.ItemsSource = lstContactModel;
                        var Selecteditem = lstbox.Items[lstbox.Items.Count - 1];
                        lstbox.ScrollIntoView(Selecteditem);
                        lstbox.UpdateLayout();
                    });
