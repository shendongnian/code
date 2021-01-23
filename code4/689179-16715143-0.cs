        public static Dictionary<T, string> GetEnumNamesFromResources<T>(ResourceManager resourceManager, params T[] excludedItems)
        {
            Contract.Requires(resourceManager != null, "resourceManager is null.");
            var dictionary =
                resourceManager.GetResourceSet(culture: CultureInfo.CurrentUICulture, createIfNotExists: true, tryParents: true)
                .Cast<DictionaryEntry>()
                .Join(Enum.GetValues(typeof(T)).Cast<T>().Except(excludedItems),
                    de => de.Key.ToString(),
                    v => v.ToString(),
                    (de, v) => new
                    {
                        DictionaryEntry = de,
                        EnumValue = v
                    })
                .OrderBy(x => x.EnumValue)
                .ToDictionary(x => x.EnumValue, x => x.DictionaryEntry.Value.ToString());
            return dictionary;
        }
