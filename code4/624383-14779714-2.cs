    static bool ShouldKeep(SampleClass item) {
        return (item.Type == SampleType.type3 && item.Items.Count == 0)
            || Items.Any(ShouldKeep);
    }
    static SampleClass Filter(SampleClass item) {
        if (!ShouldKeep(item)) return null;
        return res = new SampleClass {
            Id = item.Id
        ,   Name = item.Name
        ,   Type = item.Type
        ,   Items = item.Items.Where(ShouldKeep).Select(x=>Filter(x)).ToList()
        };
    }
