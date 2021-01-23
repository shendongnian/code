    private static IEnumerable<IEnumerable<int>> GetBoundSequences(
            Array array,
            int?[] definedBounds)
    {
        for (var rank = 0; rank < array.Rank; rank++)
        {
            var defined = definedBounds.ElementAtorDefault(rank);
            if (defined.HasValue)
            {
                yield return new[] { defined.Value };
            }
            else
            {
                var min = array.GetLowerBound(rank);
                yield return Enumerable.Range(
                    min, 
                    (array.GetUpperBound(rank) - min) + 1);
            }
        }
    }
