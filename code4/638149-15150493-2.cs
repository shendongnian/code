    public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> sequence)
    {
        if (sequence == null)
        {
            yield break;
        }
        var list = sequence.ToList();
        if (!list.Any())
        {
            yield return Enumerable.Empty<T>();
        }
        else
        {
            var startingElementIndex = 0;
            foreach (var startingElement in list)
            {
                var remainingItems = list.Where((e,i) => i != startingElementIndex);
                foreach (var permutationOfRemainder in remainingItems.Permute())
                {
                    yield return startingElement.Concat(permutationOfRemainder);
                }
                startingElementIndex++;
            }
        }
    }
    private static IEnumerable<T> Concat<T>(this T firstElement, IEnumerable<T> secondSequence)
    {
        yield return firstElement;
        if (secondSequence == null)
        {
            yield break;
        }
        foreach (var item in secondSequence)
        {
            yield return item;
        }
    }
