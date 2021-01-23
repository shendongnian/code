    IEnumerable<IEnumerable<T>> GetAllPermutations<T>(IEnumerable<IEnumerable<T>> inputLists)
    {
        if (!inputLists.Any()) return new [] { Enumerable.Empty<T>() };
        else
        {
            foreach (var perm in GetAllPermutations(inputLists.Skip(1)))
                foreach (var x in inputLists.First())
                    yield return new[]{x}.Concat(perm);
        }
    }
