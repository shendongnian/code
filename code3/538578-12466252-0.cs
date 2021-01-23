    public static IQueryable<Kolon> kolonlistele()
    {
        using (Pehlivan.pehkEntities ctx = new Pehlivan.pehkEntities())
        {
            return ctx.Kolons.ToList();
        }
    }
