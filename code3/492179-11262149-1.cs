    public static class MyExtensions
    {
        public static string GetMoney(this decimal value, bool displayCurrency = false, bool displayPeriods = true)
        {
            string ret = string.Format("{0:C}", value).Substring(displayCurrency ? 0 : 1);
            if (!displayPeriods)
            {
                ret = ret.Replace(",", string.Empty);
            }
            return ret;
        }
    }
