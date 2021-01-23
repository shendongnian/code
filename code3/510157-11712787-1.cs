    using (var bitmap = new Bitmap(@"..."))
    {
        var mostUsedColors =
            GetPixels(bitmap)
                .GroupBy(color => color)
                .OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key)
                .Take(5);
        foreach (var color in mostUsedColors)
        {
            Console.WriteLine("Color {0}", color);
        }
    }
