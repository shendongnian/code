    public class CardSuit 
    {
        public static readonly CardSuit Spades = new CardSuit();
        public static readonly CardSuit Hearts = new CardSuit();
        ...
    }
    
    public enum GameSuit : CardSuit 
    {
        public static readonly GameSuit Suns = new GameSuit();
    }
