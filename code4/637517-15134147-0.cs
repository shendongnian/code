    List<client> clientList = new List<client>();
    for (int i = 0; i < 5; i++)
    {
        client c = new client();
        c.FName = "John";
        c.FName = "Smith";
        c.age = i;
        var b = (from cl in clientList
                 where cl.FName = c.FName &&
                       cl.LName = c.LName
                 select cl).ToList().Count() <= 0;
        if (b)
        {
            clientList.Add(c);
        }
    }
