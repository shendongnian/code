    async void MyAsyncMethod()
    {
        var client = new HttpClient();
        var task = client.GetStringAsync("http://someurl.com/someAction");
        // The problem here is that GetStringAsync() may not be finished 
        // when getting the result here.
        string result = task.Result;
        // So the text would be empty here if the task is not completed.
        textBox1.Text = result; 
    }
