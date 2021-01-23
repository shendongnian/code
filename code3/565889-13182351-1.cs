    int dice = RollDice();
    
    if(RocketInSquare(playerPositions[playerNo] + dice))
    {
        playerPositions[playerNo] += dice +1;
    }
    else
    {
        playerPositions[playerNo] += dice;
    }
