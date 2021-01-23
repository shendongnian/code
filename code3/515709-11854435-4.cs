    private async void MyButtonClick(object sender, RoutedEventArgs e)
    {
        dynamic request = new SerializableDynamicObject();
        request.Operation = "test";
    
        Task<SerializableDynamicObject> task = Client(request);
        dynamic result = await task;
        // use result here
    }
