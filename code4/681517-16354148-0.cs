    var allMaxKeysForP1 = dict.Keys.Aggregate(
        new { Value = double.NegativeInfinity, Keys = new List<int>() },
        (a, k) =>
            {
                if (a.Value > dict[k].P1) return a;
                if (a.Value.Equals(dict[k].P1))
                {
                    a.Keys.Add(k);
                    return a;
                }
                return new { Value = dict[k].P1, Keys = new List<int> { k } };
            },
        a => a.Keys);
