    class Player
    {
        // Constructor. Initializes an instance of the class (an object).
        public Player (string name)
        {
            Name = name;
        }
        // Property
        public int Score { get; private set; }
        // Property
        public string Name { get; private set; }
        // Instance method (non-static method) having a parameter.
        public void IncreaseScoreBy(int points)
        {
            Score += points;
        }
        public void PrintScore()
        {
            Console.WriteLine("The winner is {0} with a score of {2} points." Name, Score);
        }
    }
