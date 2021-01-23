    public static class ExceptionHandlers<TEx>
        where TEx : Exception
    {
        public static ExceptionHandler<TEx> Handle
        {
            get;
            set;
        }
    }
