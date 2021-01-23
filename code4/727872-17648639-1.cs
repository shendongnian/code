    public IMyInterface
    {
        int ID { get; set; }
        string Name { get; set; }
    }
    public static class Mapper
    {
        public static TResult Map<TInput, TResult>(TInput t) 
            where TInput : IMyInterface
            where TResult : IMyInterface, new
        {
            return new TResult { ID = t.ID, Name = t.Name };
        }
    }
    List<T1> listOfT1 = listOfT2.Select(Mapper.Map<T1, T2>).ToList();
    List<T2> listOfT2 = listOfT1.Select(Mapper.Map<T2, T1>).ToList();
