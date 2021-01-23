     void player_CurrentStateChanged(object sender, RoutedEventArgs e)
        {
            var mediaPlayer = sender as MediaElement;
            if (mediaPlayer != null && mediaPlayer.CurrentState == MediaElementState.Playing)
            {
                var duration = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                ThreadingHelper.ExecuteAsyncAction(() =>
                    {
                        do
                        {
                            ThreadingHelper.ExecuteOnUiThread(() =>
                            {
                                Progress = mediaPlayer.Position.TotalSeconds * 100 / duration;
                            });
                            Thread.Sleep(10);
                        } while (IsPlaying);
                    });
                player.CurrentStateChanged -= player_CurrentStateChanged;
            }
        }
