    public static IEnumerable<T> ExceptOne<T>(this IEnumerable<T> enumerable, T element)
    {
        var i = 0;
        return enumerable.Where(original => !EqualityComparer<T>.Default.Equals(original, element) || ++i > 1);
    }
