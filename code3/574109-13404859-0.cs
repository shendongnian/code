    public class SecondsEditRangeFormat : DateTimeFormatMode
    {
        public override string FormatValue(object context, DateTimeFormatModeArgs args)
        {
            return args.Value.ToString("s.fff");
        }
    
        public override bool TryParse(string s, out DateTime value)
        {   
            value = DateTime.ParseExact(s, "s.fff", CultureInfo.CurrentCulture);
            return true;
        }
    }
