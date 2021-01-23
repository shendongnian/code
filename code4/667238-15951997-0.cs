    public static class ExtensionRepository
    {
        public static T AddParameter<T>(this T self, string parameterValue) where T:BaseRepository 
        {
            //...
            return self;
        }
    }
