    private void btnAsync01_Click(object sender, RoutedEventArgs e)
    {
        UpdateTxtLog("click button: " + System.DateTime.Now);
        method01Async().ContinueWith(() =>
            Dispatcher.Invoke(
                new Action(() =>
                    UpdateTxtLog("after method01Async: " + System.DateTime.Now)));
    }
