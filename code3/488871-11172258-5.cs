    static public Enum Cycle(this Enum e)
    {
    	var i = ((IConvertible)e).ToInt64(null) + 1;
    	var eT = e.GetType();
    	var next = Enum.GetName(eT, i);
        return (Enum)Enum.Parse(eT, next ?? Enum.GetName(eT, 0), false);
    }
