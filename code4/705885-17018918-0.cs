    public static void ReverseFast(string text) {
      StringBuilder reverse = new StringBuilder(text.Length);
      for (int i = text.Length - 1; i >= 0; i--) {
        reverse.Append(text[i]);
      }
    }
