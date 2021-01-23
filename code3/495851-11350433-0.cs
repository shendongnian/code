    public static bool In(this object o, IEnumerable c)
    {
        foreach (object i in c)
        {
            if (i.Equals(o))
            {
                return true;
            }
        }
        return false;
    }
