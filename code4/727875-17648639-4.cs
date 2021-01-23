    public static class Mapper<TResult>
        where TResult : IMyInterface, new
    {
        public static TResult Map<TInput, TResult>(TInput t) 
            where TInput : IMyInterface
        {
            return new TResult { ID = t.ID, Name = t.Name };
        }
    }
    List<T1> listOfT1 = listOfT2.Select(Mapper<T1>.Map).ToList();
    List<T2> listOfT2 = listOfT1.Select(Mapper<T2>.Map).ToList();
