    public static string RemoveDiacritics(this string s)
    {
        // split accented characters into surrogate pairs
        IEnumerable<char> chars = s.Normalize(NormalizationForm.FormD);
        // remove all non-ASCII characters – i.e. the accents
        return new string(chars.Where(c => c < 0x7f && !char.IsControl(c)).ToArray());
    }
