    using System.Globalization;
    using System.Linq;
    IEnumerable<string> currencySymbols = CultureInfo.GetCultures(CultureTypes.SpecificCultures) //Only specific cultures contain region information
        .Select(x => (new RegionInfo(x.LCID)).ISOCurrencySymbol)
        .Distinct()
        .OrderBy(x=>x)
