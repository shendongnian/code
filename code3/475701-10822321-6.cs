    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace CodeProjectHelpProject
    {
        public class Deck
        {
            public struct Card
            {
    
                public enum CardSuit
                {
                    Spades = 0,
                    Clubs,
                    Hearts,
                    Diamonds
                }
    
                public static readonly Card.CardSuit[] Suits = ( Card.CardSuit[])Enum.GetValues(typeof(Card.CardSuit));
    
                const char CharJoker = default(char);
    
                const char AceValue = unchecked((char)1);
    
                const char JackValue = unchecked((char)11);
    
                const char QueenValue = unchecked((char)12);
    
                const char KingValue = unchecked((char)13);
    
                public static readonly Card[] Jokers = new Card[] { new Card(CharJoker, CardSuit.Spades), new Card(CharJoker, CardSuit.Hearts) };
    
                public char Value { get; internal set; }
    
                public Card.CardSuit Suit { get; internal set; }
    
                public int Rank { get { return Convert.ToInt32(Value); } }
    
                public Card(int value)
                    : this(unchecked((char)Convert.ToInt32(value / 4)), (Card.CardSuit)(value % 13)) { }
    
                public Card(char value, CardSuit suit) : this()
                {
                    if (!Suits.Contains(suit)) throw new Exception("Invalid Suite");
                    else if (value < CharJoker) value = CharJoker;
                    value = char.ToLower(value);
                    if (value == 'k') value = Card.KingValue;
                    else if (value == 'q') value = Card.QueenValue;
                    else if (value == 'j') value = Card.JackValue;
                    else if (value == 'a') value = Card.AceValue;                
                    else Value = value;
                    if (Rank > 13 || Rank < 0) throw new Exception("Invalid Card Value");
                    Suit = suit;
                }
    
                public Card(int value, CardSuit suite) : this(unchecked((char)value), suite) { }
    
                public Card(byte value, CardSuit suite) : this((char)value, suite) { }
    
            }
    
            public readonly string Manufactuer = "v//";
    
            public List<Card> Cards { get; internal set; }
    
            public Deck(bool usesJokers = false)
            {
                Cards = new List<Card>();
                foreach (Card.CardSuit s in Card.Suits)
                    foreach (char c in Enumerable.Range(0, 13)) Cards.Add(new Card(c, s));
                if (usesJokers) Cards.AddRange(Card.Jokers);           
            }
    
            public void Shuffle(int times = 0)
            {
                this.Cards.Shuffle(times);
                this.Cards.ShuffleKnuth();
            }
    
            public void ShuffleKnuth(int times = 0)
            {
                this.Cards.ShuffleKnuth();
            }
    
            public List<Card> TakeRandom(int amount = 0)
            {
                Random rnd = new Random();
                var cards = Cards.Skip(rnd.Next(0, Cards.Count() - amount)).Take(amount).ToList();
                foreach(var c in cards) Cards.Remove(c);
                return cards;
            }
    
            public List<Card> Take(int amount = 0)
            {
                Random rnd = new Random();
                var cards = Cards.Take(amount).ToList();
                foreach (var c in cards) Cards.Remove(c);
                return cards;
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
                    foreach (CodeProjectHelpProject.Deck.Card.CardSuit s in CodeProjectHelpProject.Deck.Card.Suits)
                    {
                        var cards = Cards.Where(c => c.Suit != s).ToList();
                        cards.ForEach(c =>
                        {
                            Cards.Remove(c);
                            Cards.Insert(cards.Count / 4, c);
                        });
                    }
                } while (--times >= 0);
            }
        }
    }
