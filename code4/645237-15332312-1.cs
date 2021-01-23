    private async void btnFind_Click(object sender, RoutedEventArgs e)
    {
        Service1Client service = new Service1Client();
        string result = await service.GetItemInfoAsync(txt1.Text);
        txtb1.Text = result;
    }
