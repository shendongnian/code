    public int GetThingCount()
    {
        using (MyDataContext context = new MyDataContext())  // context is created here
        {
            return context.Things.Count();
        } // it is automatically disposed of here even in the event of an exception
    }
