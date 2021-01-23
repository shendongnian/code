    class Program
    {
        static void Main()
        {
            var model = new SomeModel
            {
                SomeString = new SomeInfo<string> { Value = "testData" },
                SomeInfo = new SomeInfo<int> { Value = 5 }
            };
            var serializer = new XmlSerializer(model.GetType());
            serializer.Serialize(Console.Out, model);
        }
    }
