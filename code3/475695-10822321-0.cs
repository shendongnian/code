    public class Deck
    {
        public class Card
        {
            public enum Suite
            {
                Spades = 0,
                Clubs,
                Hearts,
                Diamonds
            }
            public static readonly Card.Suite[] Suites = ( Card.Suite[])Enum.GetValues(typeof(Card.Suite));
            const char CharJoker = default(char);
            const char AceValue = unchecked((char)1);
            const char JackValue = unchecked((char)11);
            const char QueenValue = unchecked((char)12);
            const char KingValue = unchecked((char)13);
            public static readonly Card[] Jokers = new Card[] { new Card(CharJoker, Suite.Spades), new Card(CharJoker, Suite.Hearts) };
            public char Value { get; internal set; }
            public Card.Suite Suiet { get; internal set; }
            public int IntValue { get { return Convert.ToInt32(Value); } }
            public Card(char value, Suite suite)
            {
                if (!Enum.IsDefined(typeof(Suite), suite)) throw new Exception("Invalid Suite");
                else if (value < CharJoker) value = CharJoker;
                value = char.ToLower(value);
                if (value == 'k') value = Card.KingValue;
                else if (value == 'q') value = Card.QueenValue;
                else if (value == 'j') value = Card.JackValue;
                else if (value == 'a') value = Card.AceValue;                
                else Value = value;
                if (IntValue > 13 || IntValue < 0) throw new Exception("Invalid Card Value");
                this.Suiet = suite;
            }
            public Card(int value, Suite suite) : this(unchecked((char)value), suite) { }
            public Card(byte value, Suite suite) : this((char)value, suite) { }
        }
        public readonly string Manufactuer = "v//";
        public List<Card> Cards { get; internal set; }
        public Deck(bool usesJokers = false)
        {
            Cards = new List<Card>();
            foreach (Card.Suite s in Card.Suites)
                foreach (char c in Enumerable.Range(0, 13)) Cards.Add(new Card(c, s));
            if (usesJokers) Cards.AddRange(Card.Jokers);           
        }
        public void Shuffle(int times = 0)
        {
            this.Cards.Shuffle();
        }
        public void ShuffleKnuth(int times = 0)
        {
            this.Cards.Shuffle();
        }
        public List<Card> Take(int amount = 0)
        {
            Random rnd = new Random();
            List<Card> result = new List<Card>();
            do{
                result.Add(Cards.Skip(rnd.Next(0, Cards.Count())).Take(1).Single());
                --amount;
            }while(amount >= 0);
            result.ForEach(c => Cards.Remove(c));
            return result;
        }
    }
    public static class Extensions
    {
        public static void ShuffleKnuth(this List<CodeProjectHelpProject.Deck.Card> Cards)
        {
            Random rnd = new Random();
            for (int i = 1, e = Cards.Count(); i < e; ++i)
            {
                int pos = rnd.Next(i + 1);
                var x = Cards[i];
                Cards[i] = Cards[pos];
                Cards[pos] = x;
            }
        }
        public static void Shuffle(this List<CodeProjectHelpProject.Deck.Card> Cards, int times = 0)
        {
            do
            {
                foreach (CodeProjectHelpProject.Deck.Card.Suite s in CodeProjectHelpProject.Deck.Card.Suites)
                {
                    var cards = Cards.Where(c => c.Suiet != s).ToList();
                    cards.ForEach(c =>
                    {
                        Cards.Remove(c);
                        Cards.Insert(cards.Count / 4, c);
                    });
                }
            } while (--times >= 0);
        }
    }
