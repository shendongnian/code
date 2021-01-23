    public static MyCacheHelper
    {
        public static MyType GetMyInstance
        {
            get
            {
                if (HttpRuntime.Cache[MY_CACHE_KEY] == null)
                {
                    HttpRuntime.Cache[MY_CACHE_KEY] = new MyType();
                }
                return (MyType)HttpRuntime.Cache[MY_CACHE_KEY];
            }
        }
    }
