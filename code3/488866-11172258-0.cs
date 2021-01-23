    static public Enum Next(this Enum e)
    {
        bool found = false;
        foreach (Enum i in Enum.GetValues(e.GetType()))
        {
            if (found)
                return i;
            found = e.Equals(i);
        }
        return null;
    }
