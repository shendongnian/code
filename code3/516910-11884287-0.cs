    public void Test() {
        IEnumerable<IEnumerable<CustomObject>> data = ...;
        var result = data
            .SelectMany(x => x)
            .GroupBy(
                item => item.x,
                (key, r) => new { x = key, data = r.Select(z => z.y) }
            )
            .Select(x => new CustomObject { x = x.x, y = (int)x.data.Average() })
            .ToList();
    }
