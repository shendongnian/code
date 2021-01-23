        private readonly static object _lock = new object();
        public static T cloneObject<T>(T original, List<string> propertyExcludeList)
        {
            try
            {
                Monitor.Enter(_lock);
                T copy = Activator.CreateInstance<T>();
                PropertyInfo[] piList = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                foreach (PropertyInfo pi in piList)
                {
                    if (!propertyExcludeList.Contains(pi.Name))
                    {
                        if (pi.GetValue(copy, null) != pi.GetValue(original, null))
                        {
                            pi.SetValue(copy, pi.GetValue(original, null), null);
                        }
                    }
                }
                return copy;
            }
            finally
            {
                Monitor.Exit(_lock);
            }
        }
