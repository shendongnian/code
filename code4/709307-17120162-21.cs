    class Program
    {
        static void Main()
        {
            var list = new List<string>() { "a", "b", "c" };
            
            var instance = new ClassFromList<string>(list).Instance;
            instance.GetType().GetProperty("a").SetValue(instance, "value1", null);
            instance.GetType().GetProperty("b").SetValue(instance, "value2", null);
            instance.GetType().GetProperty("c").SetValue(instance, "value3", null);
            instance.GetType()
                    .GetProperties()
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Name + " " + x.PropertyType + " " + x.GetValue(instance, null)));
                     
            Console.Read();
        }
    }
