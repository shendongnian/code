    public class Card
    {
        public string Suit { get; set; }
        public int Value { get; set; }
        public static Card FromString(string s)
        {
            if (s == "2H") return new Card() { Suit = "Hearts", Value = 2 };
            else if (s == "....")
            ...
            else return null;
        }
    }
