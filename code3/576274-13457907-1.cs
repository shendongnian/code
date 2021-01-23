    IEnumerable<IEnumerable<bool>> EnumerateResults()
    {
        var curr = new List<bool>();
        for (var idx = 0; idx < 3; idx++) curr.Add(false);
        while (!curr.All(v => v))
        {
            var idx = 0;
            // add one with carry
            while (curr[idx]) // no index OOB, because of while condition
            {
                curr[idx] = false;
                idx++;
            }
            curr[idx] = true;
            yield return new List<bool>(curr); // clone
        }
    }
