    public static IQueryable<Person> FilterHairColors(this IQueryable<Person> subQuery, string[] hairColors)
    {
        var result = new Person[] { }.AsQueryable();
        var contains = new Dictionary<string, Expression<Func<Person, bool>>>();
        contains.Add("1", p => p.HairColor_bright);
        contains.Add("2", p => p.HairColor_brown);
        contains.Add("3", p => p.HairColor_dark);
        contains.Add("4", p => p.HairColor_red);
        foreach (var color in hairColors)
        {
            result = subQuery.Where(contains[color]).Union(result);
        }
        return result;
    }
