    public static class ObjectArrayExtensions
    {
        public static string[] ToStringArray(this object[] array, bool includeNulls = false, string nullValue = "")
        {
            IEnumerable<object> enumerable = array;
            if (!includeNulls)
                enumerable = enumerable.Where(e => e != null);
            return enumerable.Select(e => (e ?? nullValue).ToString()).ToArray();
        }
    }
