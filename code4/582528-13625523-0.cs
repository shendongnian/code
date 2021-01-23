    static int [] PlayerPositions;
    public void ResetGame()
    {
        int NumberofPlayers;
        do
        {
            Console.WriteLine("Please enter number of players (2-4): ");
            String StringNumberOfPlayers = Console.ReadLine();
            NumberofPlayers = int.Parse(StringNumberOfPlayers);
        }
        while (NumberofPlayers > 4 || NumberofPlayers < 2);
        // need get the number of players and set the required elements in
        // playerPositions to 0 on the board
        PlayerPositions = new int [NumberofPlayers];
    }
