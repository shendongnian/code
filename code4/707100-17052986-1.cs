    class Card
    {
        public string Name { get; set; }
        public int Values[] { get; set; } // alternatively, an enum
        
        // Examples of how I would expand this for use in a game
        public String Suit { get; set; } // alternatively, an enum.
        public Boolean Dealt { get; set;}
    }
