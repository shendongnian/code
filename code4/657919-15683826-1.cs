    private static string NormalizeDiacriticalCharacters(string value, bool ignoreInvalidCharacters)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }
        var normalised = value.Normalize(NormalizationForm.FormD).ToCharArray();
        if (ignoreInvalidCharacters)
        {
            return new string(normalised.Where(c => (int)c <= 127).ToArray());
        }
        return new string(normalised.ToArray());
    }
