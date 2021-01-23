        bool flag = false;    
        for (int i = 0; i < NumberOfPlayers; i++)
        {
        if(!flag)
        {
            NextMove = playerPositions[i] + DiceThrow();
            flag = true;  
        } 
        while (RocketInSquare(NextMove) == true)
            {
                playerPositions[i] = NextMove++;
            }
            playerPositions[i] = NextMove;
        }
