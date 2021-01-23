    for (int y = 0; y < GameBoard.GameBoardHeight; y++)
    {
        for (int x = 0; x < GameBoard.GameBoardWidth; x++)
        {
            if (GetSquare(x, y) == "Empty")
    	    {
                RandomPiece(x, y);
            }
        }
    }
