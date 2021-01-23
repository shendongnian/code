    void Main()
    {
        var x = new
        {
            items = new[]
            {
                new
                {
                    name = "command", index = "X", optional = "0"
                },
                new
                {
                    name = "command", index = "X", optional = "0"
                }
            }
        };
        JavaScriptSerializer js = new JavaScriptSerializer(); //system.web.extension assembly....
        Console.WriteLine(js.Serialize(x));
    }
