    public int GetThingCount()
    {
        using (MyDataContext context = new MyDataContext())
        {
            return context.Things.Count();
        }
    }
