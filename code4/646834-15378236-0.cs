       public void Apply_Cached_ReturnsReversedCachedValue()
        {
            Dictionary<string, string> cacheDict = new Dictionary<string, string>() { { "sometext", "txetemos" } };
    
            string str = "sometext";
            int dictionaryCountBeforeApply = cacheDict.Count();
            //set value to static cache field using reflection, here dictionary count is 1
            Type type = typeof(CachingDecorator);
            FieldInfo cacheFieldInfo = type.GetField("cache", BindingFlags.NonPublic | BindingFlags.Static);
            cacheFieldInfo.SetValue(decorator, cacheDict);
            string result = decorator.Apply(str);
            int dictionaryCountAfterApply = cacheDict.Count();
            Assert.AreEqual(dictionaryCountAfterApply, dictionaryCountBeforeApply);
        }
        public void Apply_NotCached_ReturnsReversed()
        {
            Dictionary<string, string> cacheDict = new Dictionary<string, string>() { };
            string str = "sometext";
            int dictionaryCountBeforeApply = cacheDict.Count();
            //set value to static cache field using reflection, here dictionary count is 0
            Type type = typeof(CachingDecorator);
            FieldInfo cacheFieldInfo = type.GetField("cache", BindingFlags.NonPublic | BindingFlags.Static);
            cacheFieldInfo.SetValue(decorator, cacheDict);
            string result = decorator.Apply(str);
            int dictionaryCountAfterApply = cacheDict.Count();
            Assert.AreNotEqual(dictionaryCountAfterApply, dictionaryCountBeforeApply);
        }`
