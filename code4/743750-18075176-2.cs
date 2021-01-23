    public void Main()
    {
        var connection = new HubConnection("http://myserver");
        var proxy = connection.CreateHubProxy("MyHub");
        proxy.On<string, int>("send", (name, age) =>
        {
            Console.WriteLine("Name {0} and age {1}", name, age);
        });
    }
