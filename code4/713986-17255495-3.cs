    [Serializable]
    public class TimeZoneInformation
    {
        public string Id { get; set; }
        public TimeSpan BaseUtcOffset { get; set; }
        public string DisplayName { get; set; }
        public string DaylightName { get; set; }
        public string StandardName { get; set; }
        public bool SupportsDST { get; set; }
        public static implicit operator TimeZoneInformation(TimeZoneInfo source)
        {
            return new TimeZoneInformation
            {
                Id = source.Id,
                DisplayName = source.DisplayName,
                BaseUtcOffset = source.BaseUtcOffset,
                DaylightName = source.DaylightName,
                StandardName = source.StandardName,
                SupportsDST = source.SupportsDaylightSavingTime,
            };
        }
        public static implicit operator TimeZoneInfo(TimeZoneInformation source)
        {
            return TimeZoneInfo.FindSystemTimeZoneById(source.Id);
        }
    }
