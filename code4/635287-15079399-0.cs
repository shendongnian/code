        public static DateTime AddDuration(this DateTime datetime, string str)
        {
            int value = 0;
            int mutiplier = str.EndsWith("d") ? 1440 : str.EndsWith("h") ?  60 : 1;
            if (int.TryParse(str.TrimEnd(new char[]{'m','h','d'}), out value))
            {
                return datetime.AddMinutes(value * mutiplier);
            }
            return datetime;
        }
