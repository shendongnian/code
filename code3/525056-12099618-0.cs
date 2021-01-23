    class Program
    {
        static void Main(string[] args)
        {
            MyMethod("Key1", 1, "Key2", 2, "Key3", 3);
        }
        static void MyMethod(params object[] alternatingKeysValues)
        {
            var dictionary = AlternatingKeysValuesToDictionary(alternatingKeysValues);
            // etc...
        }
        static Dictionary<string, object> AlternatingKeysValuesToDictionary(params object[] alternatingKeysValues)
        {
            if (alternatingKeysValues.Count() % 2 == 1)
                throw new ArgumentException("AlternatingKeysValues must contain an even number of items.");
            return Enumerable
                .Range(1, alternatingKeysValues.Count() / 2)
                .ToDictionary(
                    i => (string)alternatingKeysValues.ElementAt(i * 2 - 2),
                    i => alternatingKeysValues.ElementAt(i));
        }
    }
