    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace CodeProjectHelpProject
    {
        public class Deck
        {
            #region Nested Types
    
            //Exceptions
            internal class DeckException : Exception { public DeckException(string message) : base(message) { } public DeckException(string message, Exception inner) : base(message, inner) { } }
    
            #region CardSuit
    
            //Enumeration of Suits a Card can Obtain, Allows the Developer to change the Card Order.
            public struct CardSuit
            {
                //Exceptions
                internal class CardSuitException : DeckException { public CardSuitException(string message) : base(message) { } }
    
                #region Statics
    
                internal static int Spade = 0;
                internal static int Club = 1;
                internal static int Heart = 2;
                internal static int Diamond = 3;
    
                public static CardSuit Spades = new CardSuit(Spade);
                public static CardSuit Clubs = new CardSuit(Club);
                public static CardSuit Hearts = new CardSuit(Heart);
                public static CardSuit Diamonds = new CardSuit(Diamond);
    
                #endregion
    
                #region Fields
    
                internal int m_Suit;
    
                #endregion
    
                #region Constructor
    
                public CardSuit(int suit)
                {
                    if (suit < Spade || suit > Diamond) throw new CardSuitException("Invalid Suit");
                    m_Suit = suit;
                }
    
                #endregion
    
                #region CardSuit Overrides
    
                public override string ToString()
                {
                    switch (m_Suit)
                    {
                        case 0: return "Spades";
                        case 1: return "Clubs";
                        case 2: return "Hearts";
                        case 3: return "Diamonds";
                        default: return "Unknown";
                    }
                }
    
                #endregion
    
                #region Operators
    
                public static bool operator >(CardSuit a, CardSuit b){ return a < b;}
                public static bool operator <(CardSuit a, CardSuit b){ return a > b;}
    
                public static implicit operator int(CardSuit a) { return a.m_Suit; }
                public static implicit operator CardSuit(int a) { return new CardSuit(a); }
    
                #endregion
            }
    
            #endregion
    
            #region Card Structure
            public struct Card
            {
                //Exceptions
                internal class CardException : DeckException { public CardException(string message) : base(message) { } }
    
                #region Constants
    
                const char CharJoker = default(char);
    
                const char AceValue = unchecked((char)1);
    
                const char JackValue = unchecked((char)11);
    
                const char QueenValue = unchecked((char)12);
    
                const char KingValue = unchecked((char)13);
    
                #endregion
    
                #region Properties
    
                public char Value { get; internal set; }
    
                public Deck.CardSuit Suit { get; internal set; }
    
                public int Rank { get { return Convert.ToInt32(Value); } }
    
                #endregion
    
                #region Constructor
    
                public Card(char value, CardSuit suit, CardSuit[] possibleSuits = null)
                    : this()
                {
                    if (null == possibleSuits) possibleSuits = Deck.DefaultSuitOrder;
                    if (!possibleSuits.Contains(suit)) throw new CardSuit.CardSuitException("Invalid Suit");
                    if (value < CharJoker) value = CharJoker;
                    value = char.ToLower(value);
                    Value = value;
                    if (Rank > 13 || Rank < 0) throw new CardException("Invalid Card Value");
                    Suit = suit;
                }
    
    
                public Card(int value) : this(unchecked((char)Convert.ToInt32(value / 4)), (Deck.CardSuit)(value % 4)) { }
                
                public Card(int value, CardSuit suite) : this(unchecked((char)value), suite) { }
    
                public Card(byte value, CardSuit suite) : this((char)value, suite) { }
    
                #endregion
    
                #region Card Overrides
    
                public override string ToString()
                {
                    return "Card, " + (Value <= 0 ? "Joker" : Value == AceValue ? "Ace" : Value == JackValue ? "Jack" : Value == QueenValue ? "Queen" : Value == KingValue ? "King" : Rank.ToString()) + " Of " + Suit + " (" + Rank + ')' ;
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
    
                public override int GetHashCode() { return Value.GetHashCode() ^ Suit.GetHashCode(); }
    
                #endregion
    
                #region Card Operators
    
                public static implicit operator Card(int c) { return new Card(c); }
                public static implicit operator int(Card c) { return c.GetHashCode(); }
    
                public static bool operator ==(Card a, Card b) { return a.GetHashCode() == b.GetHashCode(); }
                public static bool operator !=(Card a, Card b) { return !(a == b); }
    
                public static bool operator >(Card a, Card b) { return a.Value >= b.Value && a.Suit > b.Suit; }
                public static bool operator <(Card a, Card b) { return a.Value <= b.Value && a.Suit < b.Suit; }
    
                #endregion
    
            }
    
    #endregion Card
    
            #endregion
    
            #region Deck Statics
    
            // Override the default order of suits here for other games, see below
            public static readonly Deck.CardSuit[] DefaultSuitOrder = new CardSuit[] { CardSuit.Spades, CardSuit.Clubs, CardSuit.Hearts, CardSuit.Diamonds };
    
            public static readonly Card[] Jokers = new Card[] { new Card(0), new Card(1), new Card(2), new Card(3) };
    
            public static bool HasAllCards(Deck d) { foreach (var c in Enumerable.Range(d.HasJokers ?  0 : 4, d.HasJokers ?  56 : 52)) if (!d.Cards.Contains(c)) return false; return true; }
    
            #endregion
    
            #region Deck Properties
    
            public readonly string Manufactuer = "v//";
    
            public List<Card> Cards { get; internal set; }
    
            public bool HasJokers { get; private set; }
    
            public bool Shuffled { get; private set; }
    
            public Card this[int index] { get { return Cards[index]; } private set { Cards[index] = value; } }
    
            public bool this[Card c] { get { return ContainsCard(c); } }
            
            public virtual bool IsLegalDeck { get { return HasJokers ? Cards.Count() == 56 : Cards.Count() == 52 && HasAllCards(); } }
    
            public CardSuit[] SuitOrder { get; private set; }
    
            #endregion
    
            #region Constructor
    
            public Deck(bool usesJokers = false, bool shuffle = false, CardSuit[] suitOrder = null)
            {
                try
                {
                    if (null == suitOrder) SuitOrder = DefaultSuitOrder;
                    else SuitOrder = suitOrder;
                    Cards = new List<Card>();
                    HasJokers = usesJokers;
                    if (HasJokers) foreach (var c in Enumerable.Range(0, 56)) Cards.Add(c);
                    else foreach (Deck.CardSuit s in SuitOrder) foreach (char c in Enumerable.Range(1, 13)) Cards.Add(new Card(c, s));
                    if (shuffle) Shuffle(1, true);
                }
                catch(Exception e) { throw new DeckException(e.Message, e); }
            }        
    
            #endregion
    
            #region Deck Methods
    
            public void Shuffle(int times = 0, bool knuthAlgorithm = false)
            {
                if (knuthAlgorithm) this.Cards.ShuffleKnuth();
                else Extensions.Shuffle(this, times);
                Shuffled = true;
            }
    
            public List<Card> Take(int amount = 0, bool random = false)
            {
                var cards = (random ? (Cards.Skip(Extensions.Random.Next(0, Cards.Count() - amount))) : (Cards.Skip(Extensions.Random.Next(0, Cards.Count() - amount))).Take(amount).ToList());
                foreach (var c in cards) Cards.Remove(c);
                return cards.ToList();
            }
    
            public List<Card> TakeRandom(int amount = 0) { return Take(amount, true); }
    
            public virtual bool RemoveCard(Card c) { return Cards.Remove(c); }
    
            public virtual void RemoveCards(bool stopIfNotContained = false, params Card[] s) { foreach (Card c in s) if (!stopIfNotContained && !RemoveCard(c)) break; return; }
    
            public virtual bool ContainsCard(Card c) { return Cards.Contains(c); }        
    
            public virtual bool HasAllCards() { return Deck.HasAllCards(this); }
    
            #endregion
    
            #region Deck Overrides
    
            public override string ToString() { return "Deck, " + Cards.Count + " Remaining Cards"; }
    
            public override int GetHashCode() { return Cards.GetHashCode(); }
    
            public override bool Equals(object obj)
            {
                if (obj is Deck)
                {
                    return ((Deck)obj).GetHashCode() == obj.GetHashCode();
                }
                return base.Equals(obj);
            }
    
            #endregion
    
            #region Deck Operators
    
            public static implicit operator int(Deck d) { return d.GetHashCode(); }
    
            public static bool operator ==(Deck a, Deck b) { return a.GetHashCode() == b.GetHashCode(); }
            public static bool operator !=(Deck a, Deck b) { return !(a == b); }
    
            public static Deck operator <<(Deck a, int b) { a.Shuffle(b); return a; }
            public static Deck operator >>(Deck a, int b) { a.Shuffle(b, true); return a; }
    
            public static List<Card> operator -(Deck d, int amount) { d.Take(amount, true); return d.Cards; }
            public static List<Card> operator +(Deck d, IEnumerable<int> cards) { foreach (int c in cards) d.Cards.Add(c); return d.Cards; }
            public static List<Card> operator +(Deck d, int card) { d.Cards.Add(card); return d.Cards; }
            public static List<Card> operator +(Deck d, IEnumerable<Card> cards) { d.Cards.AddRange(cards); return d.Cards; }
    
            public static Deck operator -(Deck a, Deck b) { a.Cards.ForEach(c => b.Cards.Remove(c)); return a; }
            public static Deck operator +(Deck a, Deck b) { a.Cards.AddRange(b.Cards); return a; }
    
            #endregion
        }
        public static class Extensions
        {
            //Cause random leaks
            public static readonly Random Random = new Random();
    
            /// <summary>
            /// Shuffles a List according to Knuth's Algorithm
            /// </summary>
            /// <param name="List">The List to shuffle</param>
            public static void ShuffleKnuth(this List<CodeProjectHelpProject.Deck.Card> List)
            {
                for (int i = 1, e = List.Count(); i < e; ++i)
                {
                    int pos = Random.Next(i + 1);
                    var x = List[i];
                    List[i] = List[pos];
                    List[pos] = x;
                }
            }        
    
            public static void Shuffle(this Deck d, int times = 0)
            {
                do
                {
                    foreach (CodeProjectHelpProject.Deck.CardSuit s in d.SuitOrder)
                    {
                        var cards = d.Cards.Where(c => c.Suit != s).ToList();
                        cards.ForEach(c =>
                        {
                            d.Cards.Remove(c);                                                
                            d.Cards.Insert(c.Value % 4, c);
                        });
                    }
                } while (--times >= 0);
            }
        }
    }
