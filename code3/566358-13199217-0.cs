    string rgb = "166, 103, 208";
    var c = Color.FromArgb(BitConverter.ToInt32(rgb.Split(',')
        .Select(s => byte.Parse(s))
        .Reverse().Union(new byte[] { 0 })
        .ToArray(), 0));
