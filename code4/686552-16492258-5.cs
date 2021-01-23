     // field declared in my class, call it game
     public char[] wordsToGuessArray { get; set; }
    
     public Game(char[] word)
     {
           wordToGuessArray = word;
     }
     // call it like this
     Game game = new Game(selectWord());
