    public int[,] GetLegalMoves()
    {
        int[,] legalMoves = new int[8, 8];
        Parallel.For(0, 8, i =>
        {
            for (int j = 0; j < 8; j++)
                if (IsMoveLegal(i, j)) legalMoves[i, j] = 1;
                else legalMoves[i, j] = 0;
        });
        return legalMoves;
    }
