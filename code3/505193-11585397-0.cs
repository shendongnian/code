    public double CalculateWinLossPercentage(List<Player> listOfPlayers,int index)
    {
        int count = listOfPlayers.GetRange(0, index + 1).Count(p => p.IsWinner);
        return ((double)count)/(index+1);
    }
