    var s1 = ToASCII("Hervé");
    var s2 = ToASCII("Mañana"); 
    string ToASCII(string s)
    {
        return String.Join("",
             s.Normalize(NormalizationForm.FormD)
            .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
    }
