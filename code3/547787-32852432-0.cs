    private void MediaPlayer_IsFullScreenChanged(object sender, Windows.UI.Xaml.RoutedPropertyChangedEventArgs<bool> e)
                {
                    Microsoft.PlayerFramework.MediaPlayer mp = (sender as Microsoft.PlayerFramework.MediaPlayer);
                    mp.IsFullWindow = !mp.IsFullWindow;
                }
