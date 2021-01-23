    using System.Globalization;
    
    string input = "rểplay";
    string decomposed = input.Normalize(NormalizationForm.FormD);
    char[] filtered = decomposed
        .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
        .ToArray();
    string newString = new String(filtered);
    string[] myArray= { "replay", "answer" };
    if (myArray.Contains(newString)) {
    //...
    }
