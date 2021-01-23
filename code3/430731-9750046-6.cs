    // Initialise piece bitboards using square contents.
    private void InitPieceBitboards()
    {
        this.WhiteKing = 0; 
        this.WhiteQueens = 0; 
        this.WhiteRooks = 0; 
        this.WhiteBishops = 0; 
        this.WhiteKnights = 0; 
        this.WhitePawns = 0;
        for (Int16 i = 0; i < 64; i++)
        {
            if (this.Squares[i] == Constants.WHITE_KING)
            {
                this.WhiteKing = this.WhiteKing | Constants.BITSET[i];
            }
            if (this.Squares[i] == Constants.WHITE_QUEEN)
            {
                this.WhiteQueens = this.WhiteQueens | Constants.BITSET[i];
            } 
            if (this.Squares[i] == Constants.WHITE_ROOK) 
            {
                this.WhiteRooks = this.WhiteRooks | Constants.BITSET[i];
            }
            if (this.Squares[i] == Constants.WHITE_BISHOP) 
            {
                this.WhiteBishops = this.WhiteBishops | Constants.BITSET[i];
            }
            if (this.Squares[i] == Constants.WHITE_KNIGHT) 
            {
                this.WhiteKnights = this.WhiteKnights | Constants.BITSET[i];
            }
            if (this.Squares[i] == Constants.WHITE_PAWN) 
            {
                this.WhitePawns = this.WhitePawns | Constants.BITSET[i];
            }
            this.WhitePieces = this.WhiteKing | this.WhiteQueens | 
                               this.WhiteRooks | this.WhiteBishops | 
                               this.WhiteKnights | this.WhitePawns;
            this.BlackPieces = this.BlackKing | this.BlackQueens | 
                               this.BlackRooks | this.BlackBishops | 
                               this.BlackKnights | this.BlackPawns;
            this.SquaresOccupied = this.WhitePieces | this.BlackPieces;
        }
    }
