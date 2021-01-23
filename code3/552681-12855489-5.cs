    // Init Zobrist position hash, used in transposition table and draw detection.
    // This will be incrementally updated during move make/unmake.
    internal static UInt64 InitPositionHash(byte[] squares, ComplexProperties propertyStore, byte sideToMove)
    {
        UInt64 positionHash = 0;
        // Calculate piece/square hashes.
        for (Int32 i = 0; i < 64; i++)
        {
            if (squares[i] != Constants.EMPTY)
            {
                positionHash ^= HashKeys.PieceSquareKeys[i, squares[i]];
            }
        }
        // Add side to move only if Black.
        if (sideToMove == Constants.BLACK)
        {
            positionHash ^= HashKeys.SideToMoveKey;
        }
        // Add en-passant square if applicable.
        if (propertyStore.EpSquare != 0)
        {
            positionHash ^= HashKeys.EnPassantKeys[propertyStore.EpSquare];
        }
        // White castling.
        switch (propertyStore.WhiteCastlingStatus)
        {
            case Constants.EnumCastlingStatus.CAN_CASTLE_BOTH:
                 positionHash ^= HashKeys.WhiteCastlingKingSideKey;
                 positionHash ^= HashKeys.WhiteCastlingQueenSideKey;
                 break;
            case Constants.EnumCastlingStatus.CAN_CASTLE_OO:
                 positionHash ^= HashKeys.WhiteCastlingKingSideKey;
                 break;
            case Constants.EnumCastlingStatus.CAN_CASTLE_OOO:
                 positionHash ^= HashKeys.WhiteCastlingQueenSideKey;
                 break;
            case Constants.EnumCastlingStatus.CANT_CASTLE:
                 break;
            default:
                 Debug.Assert(false, "White has an invalid castling status!");
                 break;
        }
        // Black castling.
        switch (propertyStore.BlackCastlingStatus)
        {
            case Constants.EnumCastlingStatus.CAN_CASTLE_BOTH:
                 positionHash ^= HashKeys.BlackCastlingKingSideKey;
                 positionHash ^= HashKeys.BlackCastlingQueenSideKey;
                 break;
            case Constants.EnumCastlingStatus.CAN_CASTLE_OO:
                 positionHash ^= HashKeys.BlackCastlingKingSideKey;
                 break;
            case Constants.EnumCastlingStatus.CAN_CASTLE_OOO:
                 positionHash ^= HashKeys.BlackCastlingQueenSideKey;
                 break;
            case Constants.EnumCastlingStatus.CANT_CASTLE:
                 break;
            default:
                 Debug.Assert(false, "Black has an invalid castling status!");
                 break;
        }
        return positionHash;
    }
