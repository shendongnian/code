    bool endGame = true;
    for (int row = 0; row < y; row++)
    {
        for (int col = 0; col < x; col++)
        {
            if (bricks[col, row].visible)
            {
                endGame = false;
            }
        }
    }
    
    if (endGame)
    {
        // End your game here
    }
