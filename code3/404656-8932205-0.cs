    class Program
    {
        static void Main(string[] args)
        {
            List<object[]> kvp = new List<object[]>()
            {
                new object[] {"2-2010", 45},
                new object[] {"IE", 26.8},
                new object[] {"Chrome", 12.8},
                new object[] {"Safari", 8.5}
            };
            var json = JsonConvert.SerializeObject(kvp);
            Console.WriteLine(json);
            
            //deserialize it to a List<object[]>
            var json2 = "[[\"2-2010\",45.0],[\"IE\", 26.8],[\"Chrome\",12.8],[\"Safari\",8.5]]";
            var kvp2 = JsonConvert.DeserializeObject<List<object[]>>(json2);
        }
    }
