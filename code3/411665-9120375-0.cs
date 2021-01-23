    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            enum Cards
            {
                TwoOFHearts,
                TwoOFClubs,
                TwoOFDiamonds,
                TwoOFSpades,
                ThreeOFHearts,
                ThreeOFClubs,
                ThreeOFDiamonds,
                ThreeOFSpades,
                FourOFHearts,
                FourOFClubs,
                FourFDiamonds,
                FourOFSpades,
                FiveOFHearts,
                FiveOFClubs,
                FiveOFDiamonds,
                FiveOFSpades,
                SixOFHearts,
                SixOFClubs,
                SixOFDiamonds,
                SixOFSpades,
                SevenOFHearts,
                SevenOFClubs,
                SevenOFDiamonds,
                SevenOFSpades,
                EightOFHearts,
                EightOFClubs,
                EightOFDiamonds,
                EightOFSpades,
                NineOFHearts,
                NineOFClubs,
                NineOFDiamonds,
                NineOFSpades,
                TenOFHearts,
                TenOFClubs,
                TenOFDiamonds,
                TenOFSpades,
                JackOFHearts,
                JackOFClubs,
                JackOFDiamonds,
                JackOFSpades,
                QueenOFHearts,
                QueenOFClubs,
                QueenOFDiamonds,
                QueenOFSpades,
                KingOFHearts,
                KingOFClubs,
                KingOFDiamonds,
                KingOFSpades,
                AceOFHearts,
                AceOFClubs,
                AceOFDiamonds,
                AceOFSpades,
        }
        Random Random = new Random();
        Cards[] CardList;
        Regex Rexex = new Regex("OF");
        static void Main(string[] args)
        {
            CardList = (Cards[])Enum.GetValues(typeof(Cards));
            ShuffleCards();
            PrintCards(5);
        }
        private static void ShuffleCards()
        {
            for (int i = CardList.Length - 1; i > 0; i--)
            {
                int n = Random.Next(i + 1);
                Cards card = CardList[i];
                CardList[i] = CardList[n];
                CardList[n] = card;
            }
        }
        private static void PrintCards(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string[] card = Rexex.Split(CardList[i].ToString());
                Console.WriteLine(string.Concat("Card ", i.ToString(), " - Value:", card[0], " Suit: ", card[1]));
            }
        }
      }
}
