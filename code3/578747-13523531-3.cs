        static void Main(string[] args)
        {
            Dictionary<string, Decimal> ThingsToAdd = new Dictionary<string, decimal>();
            Dictionary<string, Value> ThingsToPrint = new Dictionary<string, Value>();
            ThingsToAdd.Add("One", 1.0m);
            ThingsToAdd.Add("Two", 2.0m);
            foreach (KeyValuePair<string, Decimal> thing in ThingsToAdd)
            {
                Value value = new Value();
                Decimal d = thing.Value;
                value.Output = () => AddOne(d);
                ThingsToPrint.Add(thing.Key, value);
            }
            Console.WriteLine(ThingsToPrint["One"].Output());
            Console.WriteLine(ThingsToPrint["Two"].Output());
            Console.ReadKey();
        }
