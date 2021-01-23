    NextMove = playerPositions[0] + DiceThrow(); 
    for (int i = 0; i < NumberOfPlayers; i++)
    {
         while (RocketInSquare(NextMove))
              NextMove++;
         playerPositions[i] = NextMove;
    }
