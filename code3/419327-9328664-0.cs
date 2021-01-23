    using System.Linq;    
    public static string[] GetCSVsFromArray(int[] array, int limit)
    {
        int i = 0;
        return array.Select(a => a.ToString())
                    .GroupBy(a => { i += a.Length; return (i - a.Length) / limit; })
                    .Select(a => string.Join(",",a))
                    .ToArray();
    }
