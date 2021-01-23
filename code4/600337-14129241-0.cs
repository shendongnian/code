        public static string ConvertTabs(this string poorlyFormedRtf)
        {
            string result = poorlyFormedRtf.Replace("\u0009", @"\tab");
            return result;
        }
