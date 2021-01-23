    [Flags]
    public enum Languages { Ger = 1,Eng = 2,Fra = 4,Ita = 8, Rus = 16 }
   
    // ctor
    public Player(string id, Languages languages) {}
    // call
    new Player("Player A", Languages.Eng | Languages.Fra);
