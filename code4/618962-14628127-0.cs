    public class User // ???
    {
        public string Name { get; private set; }
        public string Type { get; private set; } // Should this be an enum?
        public IList<string> Addresses { get; private set; }
        // Could make this a constructor if you really want... I like the
        // explicit nature of the static factory method.
        public static User ParseLine(string line)
        {
            // TODO: Split line into components etc
        }
    }
