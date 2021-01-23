    public class CustomJsonValueProviderFactory : ValueProviderFactory
    {
    
        /// <summary>Returns a JSON value-provider object for the specified controller context.</summary>
        /// <returns>A JSON value-provider object for the specified controller context.</returns>
        /// <param name="controllerContext">The controller context.</param>
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            if (controllerContext == null)
                throw new ArgumentNullException("controllerContext");
    
            object deserializedObject = CustomJsonValueProviderFactory.GetDeserializedObject(controllerContext);
            if (deserializedObject == null)
                return null;
    
            Dictionary<string, object> strs = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
            CustomJsonValueProviderFactory.AddToBackingStore(new CustomJsonValueProviderFactory.EntryLimitedDictionary(strs), string.Empty, deserializedObject);
    
            return new DictionaryValueProvider<object>(strs, CultureInfo.CurrentCulture);
        }
            
        private static object GetDeserializedObject(ControllerContext controllerContext)
        {
            if (!controllerContext.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
                return null;
    
            string fullStreamString = (new StreamReader(controllerContext.HttpContext.Request.InputStream)).ReadToEnd();
            if (string.IsNullOrEmpty(fullStreamString))
                return null;
    
            var serializer = new JavaScriptSerializer()
            {
                MaxJsonLength = CustomJsonValueProviderFactory.GetMaxJsonLength()
            };
            return serializer.DeserializeObject(fullStreamString);
        }
    
        private static void AddToBackingStore(EntryLimitedDictionary backingStore, string prefix, object value)
        {
            IDictionary<string, object> strs = value as IDictionary<string, object>;
            if (strs != null)
            {
                foreach (KeyValuePair<string, object> keyValuePair in strs)
                    CustomJsonValueProviderFactory.AddToBackingStore(backingStore, CustomJsonValueProviderFactory.MakePropertyKey(prefix, keyValuePair.Key), keyValuePair.Value);
                    
                return;
            }
    
            IList lists = value as IList;
            if (lists == null)
            {
                backingStore.Add(prefix, value);
                return;
            }
    
            for (int i = 0; i < lists.Count; i++)
            {
                CustomJsonValueProviderFactory.AddToBackingStore(backingStore, CustomJsonValueProviderFactory.MakeArrayKey(prefix, i), lists[i]);
            }
        }
    
        private class EntryLimitedDictionary
        {
            private static int _maximumDepth;
    
            private readonly IDictionary<string, object> _innerDictionary;
    
            private int _itemCount;
    
            static EntryLimitedDictionary()
            {
                _maximumDepth = CustomJsonValueProviderFactory.GetMaximumDepth();
            }
    
            public EntryLimitedDictionary(IDictionary<string, object> innerDictionary)
            {
                this._innerDictionary = innerDictionary;
            }
    
            public void Add(string key, object value)
            {
                int num = this._itemCount + 1;
                this._itemCount = num;
                if (num > _maximumDepth)
                {
                    throw new InvalidOperationException("The length of the string exceeds the value set on the maxJsonLength property.");
                }
                this._innerDictionary.Add(key, value);
            }
        }
    
        private static string MakeArrayKey(string prefix, int index)
        {
            return string.Concat(prefix, "[", index.ToString(CultureInfo.InvariantCulture), "]");
        }
    
        private static string MakePropertyKey(string prefix, string propertyName)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                return propertyName;
            }
            return string.Concat(prefix, ".", propertyName);
        }
    
        private static int GetMaximumDepth()
        {
            int num;
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            if (appSettings != null)
            {
                string[] values = appSettings.GetValues("aspnet:MaxJsonDeserializerMembers");
                if (values != null && values.Length != 0 && int.TryParse(values[0], out num))
                {
                    return num;
                }
            }
            return 1000;
        }
    
        private static int GetMaxJsonLength()
        {
            int num;
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            if (appSettings != null)
            {
                string[] values = appSettings.GetValues("aspnet:MaxJsonLength");
                if (values != null && values.Length != 0 && int.TryParse(values[0], out num))
                {
                    return num;
                }
            }
            return 1000;
        }
    }
