    using (var context = new MyContext())
    {
        var side = new Side { Stage = context.StageONE };
        context.Sides.Add(side);
        context.SaveChanges();
    }
