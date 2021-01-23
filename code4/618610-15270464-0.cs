    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication12
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Because each card is unique you could use Flag attributed Enum see the enum below and set each item a unique value I used 2 to the power of 52
                Cards cardsdealt = Cards.Clubs_10 | Cards.Clubs_2 | Cards.Diamonds_3;
    
                if ((cardsdealt & Cards.Clubs_10) == Cards.Clubs_10)
                {
                    Console.WriteLine("Card.Clubs_10 was dealt");
                }
    
                // Storage would always be 8 bytes for the long data type
            }
    
            [Flags]
            public enum Cards : long
            {
                Spades_Ace = 1,
                Spades_2 = 2,
                Spades_3 = 4,
                Spades_4 = 8,
                Spades_5 = 16,
                Spades_6 = 32,
                Spades_7 = 64,
                Spades_8 = 128,
                Spades_9 = 256,
                Spades_10 = 512,
                Spades_Jack = 1024,
                Spades_Queen = 2048,
                Spades_King = 4096,
                Hearts_Ace = 8192,
                Hearts_2 = 16384,
                Hearts_3 = 32768,
                Hearts_4 = 65536,
                Hearts_5 = 131072,
                Hearts_6 = 262144,
                Hearts_7 = 524288,
                Hearts_8 = 1048576,
                Hearts_9 = 2097152,
                Hearts_10 = 4194304,
                Hearts_Jack = 8388608,
                Hearts_Queen = 16777216,
                Hearts_King = 33554432,
                Diamonds_Ace = 67108864,
                Diamonds_2 = 134217728,
                Diamonds_3 = 268435456,
                Diamonds_4 = 536870912,
                Diamonds_5 = 1073741824,
                Diamonds_6 = 2147483648,
                Diamonds_7 = 4294967296,
                Diamonds_8 = 8589934592,
                Diamonds_9 = 17179869184,
                Diamonds_10 = 34359738368,
                Diamonds_Jack = 68719476736,
                Diamonds_Queen = 137438953472,
                Diamonds_King = 274877906944,
                Clubs_Ace = 549755813888,
                Clubs_2 = 1099511627776,
                Clubs_3 = 2199023255552,
                Clubs_4 = 4398046511104,
                Clubs_5 = 8796093022208,
                Clubs_6 = 17592186044416,
                Clubs_7 = 35184372088832,
                Clubs_8 = 70368744177664,
                Clubs_9 = 140737488355328,
                Clubs_10 = 281474976710656,
                Clubs_Jack = 562949953421312,
                Clubs_Queen = 1125899906842620,
                Clubs_King = 2251799813685250,
    
            }
        }
    }
