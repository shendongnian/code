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
    
                public static readonly Card.CardSuit[] Suits = (Card.CardSuit[])Enum.GetValues(typeof(Card.CardSuit));
    
                const char CharJoker = default(char);
    
                const char AceValue = unchecked((char)1);
    
                const char JackValue = unchecked((char)11);
    
                const char QueenValue = unchecked((char)12);
    
                const char KingValue = unchecked((char)13);
    
                public static readonly Card[] Jokers = new Card[] { new Card(0), new Card(1), new Card(2), new Card(3), };
    
                public char Value { get; internal set; }
    
                public Card.CardSuit Suit { get; internal set; }
    
                public int Rank { get { return Convert.ToInt32(Value); } }
    
                public Card(int value)
                    : this(unchecked((char)Convert.ToInt32(value / 4)), (Card.CardSuit)(value % 4)) { }
    
    
                public Card(char value, CardSuit suit)
                    : this()
                {
                    if (!Suits.Contains(suit)) throw new Exception("Invalid Suite");
                    else if (value < CharJoker) value = CharJoker;
                    value = char.ToLower(value);
                    Value = value;
                    if (Rank > 13 || Rank < 0) throw new Exception("Invalid Card Value");
                    Suit = suit;
                }
    
                public Card(int value, CardSuit suite) : this(unchecked((char)value), suite) { }
    
                public Card(byte value, CardSuit suite) : this((char)value, suite) { }
    
                public override string ToString()
                {
                    return (Value <= 0 ? "Joker" : Value == AceValue ? "Ace" : Value == JackValue ? "Jack" : Value == QueenValue ? "Queen" : Value == KingValue ? "King" : Value.ToString()) + " Of " + Suit + " (" + Rank + ')' ;
                }
    
                public override bool Equals(object obj)
                {
                    if (obj is Card)
                    {
                        Card c = (Card)obj;
                        return c.Suit == Suit && c.Value == Value;
                    }
                    return base.Equals(obj);
                }
    
                public override int GetHashCode()
                {
                    return Value.GetHashCode() | Suit.GetHashCode();
                }
    
                public static implicit operator Card(int c) { return new Card(c); }
    
                public static implicit operator int(Card c) { return c.Rank; }
    
                public static bool operator >(Card a, Card b) { return a.Value > b.Value && a.Suit > b.Suit; }
                public static bool operator <(Card a, Card b) { return a.Value < b.Value && a.Suit < b.Suit; }
    
                public static bool operator >(Card a, int b) { Card c = b; return a.Value > c.Value && a.Suit > c.Suit; }
                public static bool operator <(Card a, int b) { Card c = b; return a.Value < c.Value && a.Suit < c.Suit; }
    
            }
    
            public readonly string Manufactuer = "v//";
    
            public List<Card> Cards { get; internal set; }
    
            public bool HasJokers { get; private set; }
    
            public Card this[int index] { get { return Cards[index]; } private set { Cards[index] = value; } }
    
            public Deck(bool usesJokers = false, bool shuffle = false)
            {
                Cards = new List<Card>();
                HasJokers = usesJokers;
                foreach (Card.CardSuit s in Card.Suits)
                {
                    foreach (char c in Enumerable.Range(HasJokers ? 0 : 1, 13)) Cards.Add(new Card(c, s));
                    if (shuffle) Shuffle();
                }
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
                var cards = Cards.Skip(Extensions.Random.Next(0, Cards.Count() - amount)).Take(amount).ToList();
                foreach (var c in cards) Cards.Remove(c);
                return cards;
            }
    
            public List<Card> Take(int amount = 0)
            {
                var cards = Cards.Take(amount).ToList();
                foreach (var c in cards) Cards.Remove(c);
                return cards;
            }
    
            public override string ToString()
            {
                return "Deck, " + Cards.Count + " Cards";
            }
    
            public virtual bool RemoveCard(Card c)
            {
                return Cards.Remove(c);
            }
    
            public virtual void RemoveCards(bool stopIfNotContained = false, params Card[] s)
            {
                foreach (Card c in s)
                {
                    if (!stopIfNotContained && !RemoveCard(c)) break;
                }
    
                return;
            }
    
            public virtual bool ContainsCard(Card c) { return Cards.Contains(c); }
    
            public virtual bool HasDuplicates()
            {
                int index = Cards.Count;
                foreach (Card c in Cards) if(index >= 0 && Cards.Skip(--index).Take(1).Single().Equals(c)) return true;
                return false;
            }
    
            public virtual bool HasAllCards()
            {
                foreach (Card.CardSuit s in Card.Suits) foreach (int c in Enumerable.Range(HasJokers ? 0 : 1, 13)) if (!Cards.Contains(new Card(c, s))) return false;
                return true;
            }
    
            public virtual bool IsLegalDeck { get { return Cards.Count() == 52 && HasAllCards(); } }
        }
    
        public static class Extensions
        {
            public static readonly Random Random = new Random();
    
            public static void ShuffleKnuth(this List<CodeProjectHelpProject.Deck.Card> Cards)
            {            
                for (int i = 1, e = Cards.Count(); i < e; ++i)
                {
                    int pos = Random.Next(i + 1);
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
