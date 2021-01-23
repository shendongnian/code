    public static class CityExt
    {
        public static SelectList GetOptions<T>() where T : struct, IConvertible
        {
            var values = EnumUtilities.GetSpacedOptions<T>();
            var options = new SelectList(values, "Value", "Text");
            return options;
        }
    
    }
    
    var types = CityExt.GetOptions<CityType>();
    var statuses = CityExt.GetOptions<CityStatus>();
