    public static T Single<T>(this IEnumerable<T> sequence, 
                              Expression<Func<T, bool>> predicate)
    {
        try
        {
            return sequence.Single(predicate.Compile());
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine("Error on predicate " + predicate);
            throw;
        }            
    }
