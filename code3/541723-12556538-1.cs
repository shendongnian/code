    public class Deck<T> : List<Card<T>> 
        where T : Card<T>
    {
        void Shuffle()
        {
            throw new NotImplementedException("Shuffle not yet implemented.");
        }
    }
    
    public class Card<T> where T : Card<T>
    {
        public Deck<T> OwningDeck { get; set; }
    }
    
    public class FooCard : Card<FooCard>
    {
    }
