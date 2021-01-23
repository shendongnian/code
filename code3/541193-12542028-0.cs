    public static IEnumerable<int> Foo(int x) {
      string s = x.ToString();
      for (int length = 1; length <= s.Length; length++) {
        for (int i = 0; i + length < s.Length; i++) {
          yield return int.Parse(s.Substring(i, length));
        }
      }
    }
