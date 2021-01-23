    void Level1Update(KeyboardState cKB, KeyboardState oKB)
    {
        int i;
        for (i = 0; i < diamondlist.Count; ++i)
        {
            if (Goallist[i].Position != diamondlist[i].Position)
                break;
        }
        // When breaked off the loop, i is never equal to list count
        if (i == diamondList.Count)
            CurrentGameState = GameState.Level2;
    }
