    public async void MyMethod()
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage responseMsg = await client.GetAsync("http://www.google.com");
        //do your work
    }
