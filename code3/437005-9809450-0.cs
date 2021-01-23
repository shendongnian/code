    public static IEnumerable<T> MergeSorted<T>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, T, int> comparer) 
    {
        using (var firstEnumerator = first.GetEnumerator())
        using (var secondEnumerator = second.GetEnumerator())
        {
            var elementsLeftInFirst = firstEnumerator.MoveNext();
            var elementsLeftInSecond = secondEnumerator.MoveNext();
            while (elementsLeftInFirst || elementsLeftInSecond)
            {
                if (!elementsLeftInFirst)
                {
                        do
                        {
                            yield return secondEnumerator.Current;
                        } while (secondEnumerator.MoveNext());
                        yield break;
                }
                if (!elementsLeftInSecond)
                {
                        do
                        {
                            yield return firstEnumerator.Current;
                        } while (firstEnumerator.MoveNext());
                        yield break;
                }
                if (comparer(firstEnumerator.Current, secondEnumerator.Current) < 0)
                {
                    yield return firstEnumerator.Current;
                    elementsLeftInFirst = firstEnumerator.MoveNext();
                }
                else
                {
                    yield return secondEnumerator.Current;
                    elementsLeftInSecond = secondEnumerator.MoveNext();
                }
            }
        }
    }
