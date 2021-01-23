    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        for (var i = 1; i <= 10; i++)
        {
            Seconds.Text = i.ToString(CultureInfo.InvariantCulture);
            await Task.Delay(1000)
        }
    }
