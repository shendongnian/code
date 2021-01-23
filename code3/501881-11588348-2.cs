    internal sealed class Move
    {
        internal Move()
        {
        }
        internal Move(byte squareFrom, byte squareTo, byte pieceMoved, byte pieceCaptured, byte piecePromoted)
        {
            this.SquareFrom = squareFrom;
            this.SquareTo = squareTo;
            this.PieceMoved = pieceMoved;
            this.PieceCaptured = pieceCaptured;
            this.PiecePromoted = piecePromoted;
        }
        // The FROM square.
        // Bits 1-3 are the board file, bits 4-6 are the board rank, bits 7-8 are unused.
        internal readonly byte SquareFrom;
        // The TO square.
        // Bits 1-3 are the board file, bits 4-6 are the board rank, bits 7-8 are unused.
        internal readonly byte SquareTo;
        // The MOVED piece.
        // Bits 1-3 are the piece type, bit 4 is the piece colour, bits 5-8 are unused.
        internal readonly byte PieceMoved;
        
        // The CAPTURED piece.
        // Bits 1-3 are the piece type, bit 4 is the piece colour, bits 5-8 are unused.
        internal readonly byte PieceCaptured;
        
        // The PROMOTED piece.
        // Bits 1-3 are the piece type, bit 4 is the piece colour, bits 5-8 are unused.
        // NB Overloaded to represent EN-PASSANT capture if promoted piece is a pawn.
        // NB Overloaded to represent CASTLING if promoted piece is a king.
        internal readonly byte PiecePromoted;
    }
