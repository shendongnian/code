    public static class DbFunctions
    {
        [DbFunction("Edm", "AddMinutes")]
        public static TimeSpan? AddMinutes(TimeSpan? timeValue, int? addValue)
        {
            return timeValue == null ? (TimeSpan?)null : timeValue.Value.Add(new TimeSpan(0, addValue.Value, 0));
        }
    }
