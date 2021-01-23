    using System;
    using System.Collections.Generic;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var deck = new List<Card>();
                for (int rank = 1; rank <= 13; ++rank)
                    foreach (Suite suite in Enum.GetValues(typeof(Suite)))
                        deck.Add(new Card {Rank = rank, Suite = suite});
                var shuffler = new Shuffler();
                shuffler.Shuffle(deck);
                // Deal the top 10 cards.
                for (int i = 0; i < 10; ++i)
                    Console.WriteLine(deck[i]);
            }
        }
        public enum Suite
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }
        public sealed class Card
        {
            public Suite Suite;
            public int Rank;
            public override string ToString()
            {
                string rank;
                switch (Rank)
                {
                    case 1:  rank = "Ace";   break;
                    case 11: rank = "Jack";  break;
                    case 12: rank = "Queen"; break;
                    case 13: rank = "King";  break;
                    default: rank = Rank.ToString(); break;
                }
                return string.Format("{0} of {1}", rank, Suite);
            }
        }
        public sealed class Shuffler
        {
            public Shuffler()
            {
                _rng = new Random();
            }
            public void Shuffle<T>(IList<T> array)
            {
                for (int n = array.Count; n > 1; )
                {
                    int k = _rng.Next(n);
                    --n;
                    T temp = array[n];
                    array[n] = array[k];
                    array[k] = temp;
                }
            }
            private readonly Random _rng;
        }
    }
