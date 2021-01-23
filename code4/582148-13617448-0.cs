    private async void buttonGo_Click(object sender, RoutedEventArgs e)
    {
      using (var client = new HttpClient())
      {
        info.Text = await client.GetStringAsync("http://localhost/");
      }
    }
