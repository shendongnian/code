    public static class LinqExt {
        public static int? ReadInt(this XElement e, string path, int? fallback = null) {
            foreach (var name in path.Split('/')) {
                e = e.Element(name);
                if (e == null) {
                    return fallback;
                }
            }
            int val;
            return int.TryParse(e.Value, out val) ? val : fallback;
        }
    }
