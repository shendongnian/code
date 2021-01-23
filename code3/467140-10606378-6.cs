    static void Main(string[] args)
    {
        using (var ents = new StackEntities())
        {
            var filter = CreateGreaterThanExpression<TestEnitity>(x => x.SortProperty, 3);
            var items = ents.TestEnitities.Where(filter).ToArray();
        }
    }
