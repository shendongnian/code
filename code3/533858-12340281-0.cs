    using System.ComponentModel;
    using System.Data.SqlTypes;
    using System.Threading;
    public static class StringUnboxer<T> {
        private static readonly object _lock = new object();
        private static T m_convertedValue = default(T);
        public static T unBox(string value) {
            try {
                Monitor.Enter(_lock);
                // Test to see if value is valid to convert to supplied type
                if (canUnBox(value)) {
                    // value is valid, return conversion
                    return m_convertedValue;
                }
                else {
                    // Conversion not possible with given string data, return default value for supplied type
                    switch (typeof(T).ToString()) {
                        // In our case, if the supplied type is System.DateTime, we want to return 
                        // System.Data.SQLTypes.SQLDateTime.MinValue (01/01/1753) instead of
                        // System.DateTime.MinValue (01/01/0001) which is the normal default value
                        case "System.DateTime":
                            return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(SqlDateTime.MinValue.ToString());
                        // Return the .NET default value for all other types
                        default:
                            return default(T);
                    }
                }
            }
            finally {
                Monitor.Exit(_lock);
            }
        }
        private static bool canUnBox(string value) {
            try {
                Monitor.Enter(_lock);
                m_convertedValue = (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFrom(value);
                return true;
            }
            catch {
                return false;
            }
            finally {
                Monitor.Exit(_lock);
            }
        }
    }
