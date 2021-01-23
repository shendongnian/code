    public static class CurrencySymbolMapper {
        /// <summary>An internal cache of previously looked up currencies.</summary>
        private static Dictionary<string, string> _currencySymbolsCache =
            new Dictionary<string, string> (StringComparer.CurrentCultureIgnoreCase);
        public static string TryGetCurrencySymbol(string threeLetterISOAlphabeticCode) {
            // TODO: Enhance to get rid of the silent exception that gets thrown when constructing a new RegionInfo(CultureInfo.LCID) temporary object
            if (threeLetterISOAlphabeticCode.Length != 3) return string.Empty;
            if (_currencySymbolsCache.ContainsKey(threeLetterISOAlphabeticCode))
                return _currencySymbolsCache[threeLetterISOAlphabeticCode];
            string currencySymbolSearchResult = string.Empty;
            try {
                currencySymbolSearchResult =
                    CultureInfo.GetCultures(CultureTypes.AllCultures)
                                .Where(c => !c.IsNeutralCulture)
                                .Select(culture => {
                                    try { return new RegionInfo(culture.LCID); }
                                    catch { return null; } // Ignore this error, but enhance future implementation to get ride of this silent exception
                                })
                                .Where(ri => ri != null && string.Equals(ri.ISOCurrencySymbol, threeLetterISOAlphabeticCode, StringComparison.OrdinalIgnoreCase))
                                .Select(ri => ri.CurrencySymbol)
                                .FirstOrDefault();
            }
            catch (Exception e) {
                // TODO: Handle error
            }
            if (currencySymbolSearchResult == null) currencySymbolSearchResult = string.Empty;
            // Saves both valid and invalid search results, just in case users hammer this method with 
            // the same invalid request many times
            _currencySymbolsCache.Add(threeLetterISOAlphabeticCode, currencySymbolSearchResult);
            return currencySymbolSearchResult;
        }
    }
