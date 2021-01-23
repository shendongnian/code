    File
        .ReadAllLines(path)
        .Select(a => a.Split(new[] { '|' }, StringSplitOptions.None))
        .Select(a => new {
            Column1 = a[2].Trim(),
            Column2 = a[5].Trim(),
            Column3 = a[6].Trim(),
            Column4 = a[11].Trim()
        })
        .ToList();
