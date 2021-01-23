    using (var bitmap = new Bitmap(@"..."))
    {
        var colorsWithCount =
            GetPixels(bitmap)
                .GroupBy(color => color)
                .Select(grp =>
                    new
                        {
                            Color = grp.Key,
                            Count = grp.Count()
                        })
                .OrderByDescending(x => x.Count)
                .Take(5);
        foreach (var colorWithCount in colorsWithCount)
        {
            Console.WriteLine("Color {0}, count: {1}",
                colorWithCount.Color, colorWithCount.Count);
        }
    }
