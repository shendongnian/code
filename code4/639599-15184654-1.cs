    public static Argument<T> HasItems<T>(this Argument<T> argument) where T: IEnumerable
    {
        if (!argument.Value.Cast<object>().Any())
        {
            throw Error.Generic(argument.Name, "Collection contains no items.");
        }
        return argument;
    }
