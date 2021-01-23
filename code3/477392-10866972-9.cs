    public static List<int> IntersectSorted(this int[] source, int[] target)
    {
        // Set initial capacity to a "full-intersection" size
        // This prevents multiple re-allocations
        var ints = new List<int>(Math.Min(source.Length, target.Length));
        var i = 0;
        var j = 0;
        while (i < source.Length && j < target.Length)
        {
            // Compare only once and let compiler optimize the switch-case
            switch (source[i].CompareTo(target[j]))
            {
                case -1:
                    i++;
                    // Saves us a JMP instruction
                    continue;
                case 1:
                    j++;
                    // Saves us a JMP instruction
                    continue;
                default:
                    ints.Add(source[i++]);
                    j++;
                    // Saves us a JMP instruction
                    continue;
            }
        }
        // Free unused memory (sets capacity to actual count)
        ints.TrimExcess();
        return ints;
    }
