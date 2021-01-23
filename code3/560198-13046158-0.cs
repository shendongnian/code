    public static class CityExt
    {
        public static SelectList GetOptions<T>() where T : struct, IConvertible
        {
            var values = EnumUtilities.GetSpacedOptions<T>();
            var options = new SelectList(values, "Value", "Text");
            return options;
        }
    
    }
    
    var types = CityTypeExt.GetOptions<CityType>();
    var statuses = CityStatusExt.GetOptions<CityStatus>();
