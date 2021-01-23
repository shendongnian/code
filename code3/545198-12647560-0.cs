    public static class Thing
    {
        DomainContext _Context = new DomainContext();
        public static void mymethod()
        {
            var q = _context.GetMyEntitiesQuery().Where(x => x.Name == name );
            ...
        }
    }
