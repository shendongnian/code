        var l = Enumerable.Range(0, 1000).ToList<int>();
            int size = 11;
            var result = Enumerable.Range(0, l.Count / size + 1)
                .Select(p => l.Skip(p * size).Take(Math.Min(size, l.Count - size * p)).ToList())
                .Where(p=>p.Count > 0).ToList();
