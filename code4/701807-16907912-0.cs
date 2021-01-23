    Dictionary<Personality, int> dict =
        youngerPersons.GroupBy(p => p.Personality)
                      .ToDictionary(g => g.Key, g => g.Count());
    int samePersonalityMatches =
        olderPersons.Select(
                         q => dict.ContainsKey(q.Personality) ?
                         dict[q.Personality] : 0
                     )
                    .Sum();
