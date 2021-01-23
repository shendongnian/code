    public static IEnumerable<Person> SearchByPhone<T>(T value, Expression<Func<Person, T>> mapFunc)
    {
        return from person in personCollection
               where (mapFunc.Compile()(person)).Equals(value)
               select person;
    }
