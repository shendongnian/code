    private static IEnumerable<string> GetDescriptions(Enum value)
    {
        var descs = new List<string>();
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        var field = type.GetField(name);
        var fds = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
        foreach (DescriptionAttribute fd in fds)
        {
            descs.Add(fd.Description);
        }
        return descs;
    }
