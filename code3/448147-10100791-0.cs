    // TODO: Think of a better class name - this one sucks :)
    public static class MoreConvert
    {
        public static DateTime? ToDateTimeOrNull(string text)
        {
            return text == null ? (DateTime?) null : Convert.ToDateTime(text);
        }
    }
