    public static List<Delegate> RetrieveAllAttachedEventHandlers(Control c)
    {
        List<Delegate> result = new List<Delegate>();
        foreach (EventInfo ei in c.GetType().GetEvents())
        {
            var handlers = RetrieveControlEventHandlers(c, ei.Name);
            if (handlers != null) // Does it have any attached handler?
                result.AddRange(handlers);
        }
        return result;
    }
