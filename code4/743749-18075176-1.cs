    public void Main()
    {
        var connection = new HubConnection("http://myserver");
        var proxy = connection.CreateHubProxy("MyHub");
        var subscription = proxy.Subscribe("send");
        subscription.Received += arguments =>
        {
            string name = null;
            int age;
            if (arguments.Count > 0)
            {
                name = arguments[0].ToObject<string>();
            }
            if (arguments.Count > 1)
            {
                age = arguments[1].ToObject<int>();
            }
            Console.WriteLine("Name {0} and age {1}", name, age);
        };
    }
