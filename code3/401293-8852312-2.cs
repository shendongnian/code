    var dict = Enum.GetValues(typeof(PackageMedium))
                   .Cast<PackageMedium>()
                   .Select(v => Tuple.Create(v == PackageMedium.CDROM ? "CD-ROM" : v.ToString(), v))
                   .ToDictionary(t => t.Item1, t => t.Item2);
    var myEnumVal = dict["CD-ROM"];
