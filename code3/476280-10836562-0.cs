    public override int SaveChanges()
    {
        foreach (var bar in Bars.Local.ToList())
        {
            if (bar.Foo == null)
            {
                Bars.Remove(bar);
            }
        }
        return base.SaveChanges();
    }
