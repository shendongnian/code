    /// <summary>
    /// Projects any <see cref="IEnumerable"/>, e.g. an <see cref="ArrayList"/>
    /// to an generic <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type to project to.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <param name="map">The mapping function.</param>
    /// <returns>A sequence of <typeparamref name="T"/>.</returns>
    public static IEnumerable<T> Select<T>(this IEnumerable source, Func<object, T> map)
    {
        foreach(var item in source)
        {
            yield return map(item);
        }
    }
