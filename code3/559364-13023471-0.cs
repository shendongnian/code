    public Player(int identity, GameBoard Board)
    {
        ID = identity;
        for (int i = 0; i < 4; i++)
        {
            Pieces[i] = new GamePiece(ID, Board.GetPlaceSize(), Board.GetPieceColor(ID), Board);
            Pieces[i].Tag = ID;
            Pieces[i].Click += pieces_Click;
        }
