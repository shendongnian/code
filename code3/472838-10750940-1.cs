    private enum Ranks
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        . . .
        Jack = 11,
        Queen = 12,
        King = 13
    }
    public void SomeMethod()
    { 
        Ranks rank = Ranks.Jack;
        int rankValue = (int)rank;
        string rankName = rank.ToString();
    }
    public Ranks GetRank(int i)
    {
        string name = Enum.GetName(typeof (Ranks), i);
        if (null == name) throw new Exception();
        return (Ranks)Enum.Parse(typeof (Ranks), name);
    }
    
