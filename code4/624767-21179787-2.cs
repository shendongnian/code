    IEnumerable<T> GetChart<T>() where T : IHourlyChart, new()
    {
        //find necessary method and invoke. may be:
        return repository.GetType()
                         .GetMethods()
                         .Single(x => x.ReturnType == typeof(IEnumerable<T>))
                         .Invoke(repository, new object[0]) as IEnumerable<T>;
    }
