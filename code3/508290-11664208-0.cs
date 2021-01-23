    public static class Demoralize {
        public static void Demoralize(this IDemoralize obj,
             Func<IDemoralize, bool> CustomDemoralization) {...}
        public static void WriteModel(this IDemoralize obj,
             Func<IDemoralize, bool> Write) {...}
    }
