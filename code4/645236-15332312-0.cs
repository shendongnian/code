    private void btnFind_Click(object sender, RoutedEventArgs e)
    {
        Service1Client service = new Service1Client();
        txtb1.Text = service.GetItemInfoAsync(txt1.Text);
    }
