    private async void MyButtonClick(object sender, RoutedEventArgs e)
    {
        var request = new SerializableDynamicObject();
        dynamic dynamicRequest = request;
        dynamicRequest.Operation = "test";
    
        var task = Client(request);
        dynamic result = await task;
        // use result here
    }
