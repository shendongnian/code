    public static IEnumerable<string> GetCombinations(int[] set, int sum, string values) {
      for (int i = 0; i < set.Length; i++) {
        int left = sum - set[i];
        string vals = set[i] + "," + values;
        if (left == 0) {
          yield return vals;
        } else {
          int[] possible = set.Take(i).Where(n => n <= sum).ToArray();
          if (possible.Length > 0) {
            foreach (string s in GetCombinations(possible, left, vals)) {
              yield return s;
            }
          }
        }
      }
    }
