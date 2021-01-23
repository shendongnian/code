    using System.Linq;
    public static string[] Convert(this ArrayList items)
    {
        return items == null
            ? null
            : items.Cast<object>()
                .Select(x => x == null ? null : x.ToString())
                .ToArray();
    }
