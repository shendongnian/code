    public int CheckGoodness(bool playerID)
    {
        playerID = -playerID;
        if (!endConditionMet)
        {
            goodness = CheckGoodness(playerID);
        }
        return goodness;
    }
