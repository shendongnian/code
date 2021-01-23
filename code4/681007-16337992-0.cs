        static DateTime? TestDate(string date)
        {
            DateTime result;
            if (DateTime.TryParse("", out result))
            {
                return result;
            }
            return null;
        }
