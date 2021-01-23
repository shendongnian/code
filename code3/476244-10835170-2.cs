    public bool AreSameAsMultiSets(List<T> first, List<T> second) {
        Dictionary<T, int> counts = new Dictionary<T, int>();     
        foreach (var item in first) {
            if (!counts.ContainsKey(item)) {
                counts.Add(item, 0);
            }
            counts[item] = counts[item] + 1;
        }
        foreach (var item in second) {
            if (!counts.ContainsKey(item)) {
                return false;
            }
            counts[item] = counts[item] - 1;
        }
        foreach (var entry in counts) {
            if (entry.Value != 0) {
                return false;
            }
        }
        return true;
    }
