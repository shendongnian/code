    public class Card {
        public CARDS Val { get; set; }
        public SUITS Suit { get; set; }
        // added ToString for program below
        public override string ToString() {
            return string.Format("{0} of {1}", Val, Suit);
        }
    }
    class Program {
        static IEnumerable<Card> RandomList(int size) {
            var r = new Random((int)DateTime.Now.Ticks);
            var list = new List<Card>();
            for (int i = 0; i < size; i++) {
                list.Add(new Card {
                    Suit = (SUITS)r.Next((int)SUITS.Diamonds, (int)SUITS.Spades),
                    Val = (CARDS)r.Next((int)CARDS.Two, (int)CARDS.Ace)
                });
            }
            return list.OrderBy(c => c.Val);
        }
        // generates a random list of 5 cards untill
        // the are in sequence, and then prints the
        // sequence
        static void Main(string[] args) {
            IEnumerable<Card> consecutive = null;
            do {
                // generate random list
                var hand = RandomList(5);
                // Aggreate:
                // the passed in function is run for each item
                // in hand. acc is the accumulator value.
                // It is passed in to each call. The new List<Card>()
                // parameter is the initial value of acc when the lambda
                // is called on the first item in the list
                // in the lambda we are checking to see if the last
                // card in the accumulator value is one less
                // than the current card. If so, add it to the
                // accumulator, otherwise do not.
                consecutive = hand.Aggregate(new List<Card>(), (acc, card) => {
                    var size = acc.Count != 0
                        ? ((int)card.Val) - ((int)acc[acc.Count - 1].Val)
                        : 1;
                    if (size == 1)
                        acc.Add(card);
                    return acc;
                });
            } while (consecutive.Count() != 5);
            foreach (var card in consecutive) {
                Console.WriteLine(card);
            }
            Console.ReadLine();
        }
    }
