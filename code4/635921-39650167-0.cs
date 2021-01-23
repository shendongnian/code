    public Person LookupPerson(string emailAddress, DateTime effectiveDate)
    {
        Expression<Func<Person, bool>> criteria = 
            p =>
                p.EmailAddress == emailAddress &&
                p.EffectiveDate == effectiveDate;
        return LookupPerson(_context.ObjectSet<Person>.Local.AsQueryable(), criteria) ?? // Search local
               LookupPerson(_context.ObjectSet<Person>.AsQueryable(), criteria); // Search database
    }
    private Person LookupPerson(IQueryable<Person> source, Expression<Func<Person, bool>> predicate)
    {
        return source.FirstOrDefault(predicate);
    }
