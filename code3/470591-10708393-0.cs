    IDictionaryEnumerator CacheEnum = HttpRuntime.Cache.GetEnumerator();
        while (CacheEnum.MoveNext()) {
            MyClass mc = ((DictionaryEntry)CacheEnum.Current).Value as MyClass;
                if (mc != null) {
                    // Doing stuff...
