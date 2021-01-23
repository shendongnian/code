    public bool MakeMove (int row, int column, bool move)
    {
        if (_winner.HasValue)
            throw new InvalidOperationException ("The game is already won.");
        if (_data [row][column].HasValue)
            throw new InvalidOperationException ("This cell is already taken.");
        _data [row][column] = move;
        _winner = FindWinner ();
        return move == _winner;
    }
    public bool? Winner {
        get { return _winner; }
    }
