    private async void Button_Click( object sender, RoutedEventArgs e )
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("http://api.voicerss.org?key=97a912d2574c4538afbf0919ad1f5402&hl=fr-fr&src=hello");
        var content = await response.Content.ReadAsStreamAsync();
        ME.SetSource(new MemoryRandomAccessStream(content), "");
        ME.Play();
    }
