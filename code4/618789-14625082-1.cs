    var model = new MyViewModel
    {
        Fields = new[]
        {
            new Field { Name = "john", Value = "lorem" },
            new Field { Name = "smith", Value = "ipsum" },
        }
    };
    var serializer = new XmlSerializer(typeof(MyViewModel));
    serializer.Serialize(Console.Out, model);
