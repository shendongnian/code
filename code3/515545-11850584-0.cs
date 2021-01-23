        dynamic something = new {id = "1", name = "name"};
        Type type = something.GetType();
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetGetMethod().Invoke(something, null);
            Console.WriteLine(string.Format("{0}:{1}", property.Name, value));
        }
