    public static IEnumerable<double> Modes(this IEnumerable<double> list)
        {
            var modesList = list
                .GroupBy(values => values)
                .Select(valueCluster =>
                        new
                            {
                                Value = valueCluster.Key,
                                Occurrence = valueCluster.Count(),
                            })
                .ToList();
 
            int maxOccurrence = modesList
                .Max(g => g.Occurrence);
 
            return modesList
                .Where(x => x.Occurrence == maxOccurrence && maxOccurrence > 1) // Thanks Rui!
                .Select(x => x.Value);
        }
    }
