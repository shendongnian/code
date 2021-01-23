    var streaks = teamResults.Aggregate(
        new {
            Current = new Dictionary<string, int>(),
            Best = new Dictionary<string, int>()
        },
        (p, r) =>
        {
            int current = 0;
            p.Current.TryGetValue(r.Team, out current);
            if (r.Won)
            {
                p.Current[r.Team] = current + 1;
            }
            else
            {
                int best = 0;
                p.Best.TryGetValue(r.Team, out best);
                if (current > best)
                {
                    p.Best[r.Team] = current;
                }
                p.Current[r.Team] = 0;
            }
            return p;
        },
        p =>
        {
            foreach (string t in p.Current.Keys)
            {
                int current = p.Current[t];
                int best = 0;
                p.Best.TryGetValue(t, out best);
                if (current > best)
                {
                    p.Best[t] = current;
                }
            }
            return p.Best.Select(kvp =>
                new{ Team = kvp.Key, StreakLength = kvp.Value });
        });
