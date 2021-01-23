    public static class BooleanExtender
    {
        public static Boolean AllAreFalse(this Boolean[] items)
        {
            for (var i = 0; i < items.Length; i++)
                if (items[i]) return false;
            return true;
        }
        public static Boolean AllAreTrue(this Boolean[] items)
        {
            for (var i = 0; i < items.Length; i++)
                if (!items[i]) return false;
            return true;
        }
    }
    new Boolean[]{ ... }.AllAreTrue();
    new Boolean[]{ ... }.AllAreFalse();
