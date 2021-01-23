    private void playCustomFile_Click(object sender, RoutedEventArgs e)
    {
      if (string.IsNullOrEmpty(fileUrl.Text.Trim().ToString()))
         MessageBox.Show("Please enter url first");
      else
         BackgroundAudioPlayer.Instance.Track = new AudioTrack(new Uri(fileUrl.Text.Trim().ToString(), UriKind.Absolute), "title","artist","album", new Uri("albumArtUrl",UriKind.RelativeOrAbsolute));
    }
