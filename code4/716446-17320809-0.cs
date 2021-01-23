    public enum FilterState
    {
        Apples = 1,
        Oranges,
        Strawberries,
        Cherries,
        Total
    }
    public void FilterChoice (int value)
    {
        int counter = 1;
        for (int i = 1; i < Total; i++)
            if (value & (counter << i))
                //actions to do if value is set
            else
                //actions if not set...
    }
