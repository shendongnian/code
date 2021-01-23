    private static string NormalizeDiacriticalCharacters(string value)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }
        var normalised = value.Normalize(NormalizationForm.FormD).ToCharArray();
        return new string(normalised.Where(c => (int)c <= 127).ToArray());
    }
