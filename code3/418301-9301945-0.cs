    var disjunction = new Disjunction()
        .Add(Restriction.Eq("WindowID", item1))
        .Add(Restriction.Eq("WindowID", item2))
        .Add(Restriction.Eq("WindowID", item3));
    // Or use a loop if you like...
    var list = CurrentSession.CreateCriteria<Table1Entity>()
        .Add(Restrictions.Eq("ColorID", colorID))
        .CreateCriteria("Table2EntityList")
        .Add(disjunction);
