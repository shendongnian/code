    public static class Ext
    {
        public static void SafeDispose(this object obj)
        {
            if (obj != null)
                obj.Dispose();
        }
    }
    ...
    var a = new ...;
    a.SafeDispose();
