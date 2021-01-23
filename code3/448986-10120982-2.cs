    public static int ClosestTo(this IEnumerable<int> collection, int target)
    {
        // NB Method will return int.MaxValue for a sequence containing no elements.
        // Apply any defensive coding here as necessary.
        var closest = int.MaxValue;
        var minDifference = int.MaxValue;
        foreach (var element in collection)
        {
            var difference = Math.Abs((long)element - target);
            if (minDifference > difference)
            {
                minDifference = (int)difference;
                closest = element;
            }
        }
        return closest;
    }
