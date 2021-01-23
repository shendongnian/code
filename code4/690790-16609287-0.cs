    public static IEnumerable<TElement> DistinctBy<TElement, TProperty>
        (this IEnumerable<TElement> elements, 
              Func<TElement, TProperty> propertySelector)
    {
        HashSet<TProperty> seenProperties = new HashSet<TProperty>();
        foreach (TElement element in elements)
        {
            if (seenProperties.Add(propertySelector(element)))
            {
                yield return element;
            }
        }
    }
