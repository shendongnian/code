    public static string TranslateChars(this string s, string originalChars,
                                                       string replacementChars)
    {
        if (String.IsNullOrEmpty(s)) {
            return s;
        }
        if (originalChars == null) {
            throw new ArgumentNullException(originalChars);
        }
        if (replacementChars == null) {
            throw new ArgumentNullException(replacementChars);
        }
        if (originalChars.Length != replacementChars.Length) {
            throw new ArgumentException(
                       "'originalChars' and 'replacementChars' must have same length.");
        }
        // Fill translation dictionary
        var translations = new Dictionary<char, char>(originalChars.Length);
        for (int i = 0; i < originalChars.Length; i++) {
            translations.Add(originalChars[i], replacementChars[i]);
        }
        //Translate
        var sb = new StringBuilder(s);
        for (int i = 0; i < sb.Length; i++) {
            char replacement;
            if (translations.TryGetValue(sb[i], out replacement)) {
                sb[i] = replacement;
            }
        }
        return sb.ToString();
    }
