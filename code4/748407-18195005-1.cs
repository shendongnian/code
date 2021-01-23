    public static class MyHelpers {
        public static IEnumerable<string> ReplaceFirstOccurrencesWithEmpty(this IEnumerable<string> @this, IEnumerable<string> a) {
            // prepare a HashSet<string> to know how many A elements there still exist
            var set = new Hashset<string>(a);
            // iterate and apply the rule you asked about
            // virtually forever (if needed)
            foreach (var value in @this) {
                if (set.Remove(value))
                    yield return "";
                else
                    yield return value;
            }
        }
    }
