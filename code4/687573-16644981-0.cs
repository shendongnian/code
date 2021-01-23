    private const string NULL_STRING = "__@NULL@__";
    public static string StringifyIfNull(this string s) {
      return s == null ? NULL_STRING : s;
    }
    public static string DestringifyIfNull(this string s) {
      return NULL_STRING == s ? null : s;
    }
