        public static String RemoveAccentsAndDiacritics(this String s)
        {
            return string.Join(string.Empty,
                               s
                                   .Normalize(NormalizationForm.FormD)
                                   .Where(c => 
                                      CharUnicodeInfo.GetUnicodeCategory(c) != 
                                          UnicodeCategory.NonSpacingMark));
        }
