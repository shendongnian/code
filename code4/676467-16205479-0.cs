    public static class Extensions {
        public static bool ToBool(this string s) {
            return s == "0" ? false : true;
        }
    }
