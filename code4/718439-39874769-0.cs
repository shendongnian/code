        public static class SystemActivator
        {
            private static Dictionary<Type, object> _mockObjects;
            private static Dictionary<Type, object> MockObjects
            {
                get { return _mockObjects; }
                set
                {
                    if (value.Any(keyValuePair => keyValuePair.Value.GetType() != keyValuePair.Key))
                    {
                        throw new InvalidCastException("object is not of the correct type");
                    }
                    _mockObjects = value;
                }
            }
            [Conditional("DEBUG")]
            public static void SetMockObjects(Dictionary<Type, object> mockObjects)
            {
                MockObjects = mockObjects;
            }
            public static void Reset()
            {
                MockObjects = null;
            }
            public static object CreateInstance(Type type)
            {
                if (MockObjects != null)
                {
                    return MockObjects.ContainsKey(type) ? MockObjects[type] : Activator.CreateInstance(type);
                }
                return Activator.CreateInstance(type);
            }
        }
