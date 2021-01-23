        static void Main(string[] args) {
            Console.WriteLine("Enter your Card Number");
            char[] card = Console.ReadLine().ToCharArray();
            int[] card_m = { 1, 2 };
            for (int idx = 0; idx < card.Length; idx++) {
                int number = (int) char.GetNumericValue(card[idx]);
                Console.WriteLine("Converted Number: {0}", number);
                // pull the multiplier from the card_m array
                int m = card_m[idx % card_m.Length];
                Console.WriteLine("Card Number Multiplier: {0}", m);
            }
            Console.Read();
        }
