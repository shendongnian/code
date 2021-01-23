    enum OrderableColumns {UserID, FirstName, ...}
    IOrderedEnumerable<SuperHero> OrderBy(SuperHeroes superheroes, OrderableColumns column)
    {
        switch(column)
        {
            case UserID:
                return superheroes.OrderBy(x => x.UserID);
            case FirstName:
                return superheroes.OrderBy(x => x.FirstName);
            ...
        }
    }
    IOrderedEnumerable<SuperHero> ThenBy(IOrderedEnumerable<SuperHero> superheroes, OrderableColumns column)
    {
        switch(column)
        {
            case UserID:
                return superheroes.ThenBy(x => x.UserID);
            case FirstName:
                return superheroes.ThenBy(x => x.FirstName);
            ...
        }
    }
    IOrderedEnumerable<SuperHero> OrderSuperheroes(SuperHeroes superheroes, params OrderableColumns[] columns)
    {
         var ordered = OrderBy(superheroes, columns[0]);
         foreach(var col in columns.Skip(1))
             ordered = ThenBy(ordered, col);
         return ordered;
    }
