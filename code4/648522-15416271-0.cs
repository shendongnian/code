    List<Spot> CheckMoves(Spot curSpot, int remainingMoves, List<Spot> moveHistory)
    {
        List<Spot> retMoves = new List<Spot>();
        if( remainingMoves == 0 )
        {
            retMoves.Add(curSpot);
            return retMoves;
        }
        else
        {
            moveHistory.Add(curSpot);
            if( !moveHistory.Contains(Spot.North) )
            {
    
                retMoves.AddRange( CheckMoves( Spot.North, remainingMoves - 1, moveHistory );
            }
            /* Repeat for E, W, S */
        }
    }
