    public static class DoubleExtensions {
        public static string ToCustomString(this double value) {
            var absValue = Math.Abs(value);
            if (absValue < 1)
                return string.Format("{0:N3}", value);
            if (absValue < 100)
                return string.Format("{0:N2}", value);
            return string.Format("{0:N0}", value);
        }
    }
