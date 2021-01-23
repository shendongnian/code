        var obj = new Item
        {
            Value = "Something",
            ChildList = new[]
            {
                new Item
                {
                    Value = "Something",
                    ChildList = new[]
                    {
                        new Item
                        {
                            Value = "Something",
                            ChildList = new[] { new Item() {Value = "End"} }
                        }
                    }
                }
            }
        };
        
        var serializer = new XmlSerializer(typeof(Item));
        
        using (var writer = new StringWriter())
        {
            serializer.Serialize(writer, obj);
            Console.WriteLine(writer.ToString());
            Console.Read();
        }
