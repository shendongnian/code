    public static class DapperExtensions
    {
        public static void ClearTableCache<TDatabase>(this Database<TDatabase> dapperDb)
        {
            var fld = dapperDb.GetType().GetField("tableNameMap", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (fld == null)
                throw new NotSupportedException("Unable to locate Private field tableNameMap");
            var obj = fld.GetValue(null);
            if (obj == null)
                throw new NotSupportedException("Unable to get value from tableNameMap");
            var clear = obj.GetType().GetMethod("Clear");
            if (clear == null)
                throw new NotSupportedException("Unable to locate ConcurrentDictionary<T, U>.Clear");
            clear.Invoke(obj, null);
        }
        public static void ClearParamCache<TDatabase>(this Database<TDatabase> dapperDb)
        {
            var fld = dapperDb.GetType().GetField("paramNameCache", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (fld == null)
                throw new NotSupportedException("Unable to locate Private field paramNameMap");
            var obj = fld.GetValue(null);
            if (obj == null)
                throw new NotSupportedException("Unable to get value from paramNameMap");
            var clear = obj.GetType().GetMethod("Clear");
            if (clear == null)
                throw new NotSupportedException("Unable to locate ConcurrentDictionary<T, U>.Clear");
            clear.Invoke(obj, null);
        }
    }
