    public static class StringMethods
    {
        /// <summary>
        /// Remove nordic characters and accents
        /// Example
        ///     "ÅÄÖ / \\íå íàøëîñü ôîðìû äëÿ îòïðàâêè" will be returned as "AAO / \\ia iaøeinu oiðiu aey ioiðaaee"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string RemoveDiacritics(this string s)
        {
            string normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }
    
        /// <summary>
        /// Make string variable safe
        /// Example
        ///     "ÅÄÖ / \\íå íàøëîñü ôîðìû äëÿ îòïðàâêè" will be returned as "AAOiaiaeinuoiiuaeyioiaaee"
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string VariableSafeString(this string s)
        {
            return Regex.Replace(s.RemoveDiacritics(), "[^0-9a-zA-Z]+", "");
        } 
    }
