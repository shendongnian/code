    Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    foreach (GoogleMusicPlaylist p in pls.UserPlaylists)
                    {
                        lbPlaylists.Items.Add(p.Title);
                    }
                });
