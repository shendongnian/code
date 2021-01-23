    bool CanMove(int x, int y)
    {
        for (int r = 0; r < 5; r++)
        {
            for (int c = 0; c < 5; c++)
            {
                if ( boardSpaces[r,c] == false )
                {
                    // do the checks here and eventually return false
                }
            }
        }
        
        return true;
    }
