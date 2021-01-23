    public Person GetPerson(Expression<Func<Person, bool>> predicate)
    {
        return (new myDbContext()).GetTable<Person>()
            .First(predicate);
    }
