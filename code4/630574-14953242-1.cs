        var numbers = new int[] { 1, 2, 3, 4, 5, 6, 8, 10, 11, 12 };
        var groups = new Dictionary<int, int>();
        groups.Add(numbers.First(), numbers.First());
        foreach (var num in numbers.Skip(1))
        {
            var grp = groups.Last();
            if (grp.Value + 1 == num)
            {
                groups[grp.Key] = num;
            }
            else
            {
                groups.Add(num, num);
            }
        }
        var output = string.Join(",", groups.Select(grp => (grp.Key == grp.Value) ? grp.Value.ToString() : grp.Key.ToString() + "-" + grp.Value.ToString()));
