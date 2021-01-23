    var chars = from character in valToCheck.Normalize(NormalizationForm.FormD)
                where CharUnicodeInfo.GetUnicodeCategory(character)
                        != UnicodeCategory.NonSpacingMark
                select character;
    return string.Join("", chars).Normalize(NormalizationForm.FormC);
