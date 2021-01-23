    Foo foo = new Foo
    {
        Date1 = DateTime.Now,
        Date2 = DateTime.Now,
        Date3 = DateTime.Now
    };
    string json = JsonConvert.SerializeObject(foo, Formatting.Indented);
    Console.WriteLine(json);
