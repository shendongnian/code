    public static IEnumerable<int> ExtractInt32(this IEnumerable<string> values) {
        foreach(var s in values) {
            int i;
            if(int.TryParse(s, out i)) yield return i;
        }
    }
