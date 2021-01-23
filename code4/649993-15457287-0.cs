        public enum Suit {Spades, Hearts, Clubs, Diamonds}
        public enum FaceValue { Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King }
        public static void Main()
        {
            var cards =
                (from suit in Enum.GetValues(typeof(Suit)).Cast<Suit>()
                 from face in Enum.GetValues(typeof(FaceValue)).Cast<FaceValue>()
                 select new { Suit = suit, Face = face })
                 
                 .ToList();
            foreach (var card in cards)
                Console.WriteLine("{0} {1}", card.Face, card.Suit);
            Console.ReadLine();
        }
