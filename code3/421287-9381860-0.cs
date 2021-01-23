    public string SafeSubstring(this string text, int index, int count)
    {
        // TODO: null checking
        return text.Length > index + count ? text.Substring(index, count)
                                           : text.Substring(index);
    }
