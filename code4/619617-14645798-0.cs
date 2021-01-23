    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Drawing;
    namespace Demo
    {
        public static class Program
        {
            private static void Main(string[] args)
            {
                var properties = new PropertyBag();
                properties["Colour"]   = Color.Red;
                properties["π"]        = Math.PI;
                properties["UserId"]   = "My User ID";
                properties["UserName"] = "Matthew";
                // Enumerate all properties.
                foreach (var property in properties)
                {
                    Console.WriteLine(property.Key + " = " + property.Value);
                }
                // Check if property exists:
                if (properties["UserName"] != null)
                {
                    Console.WriteLine("[UserName] exists.");
                }
                // Get a property:
                double π = (double)properties["π"];
                Console.WriteLine("Pi = " + π);
            }
        }
        public sealed class PropertyBag: IEnumerable<KeyValuePair<string, object>>
        {
            public object this[string propertyName]
            {
                get
                {
                    if (propertyName == null)
                    {
                        throw new ArgumentNullException("propertyName");
                    }
                    if (_dict.ContainsKey(propertyName))
                    {
                        return _dict[propertyName];
                    }
                    else
                    {
                        return null;
                    }
                }
                set
                {
                    if (propertyName == null)
                    {
                        throw new ArgumentNullException("propertyName");
                    }
                    _dict[propertyName] = value;
                }
            }
            public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
            {
                return _dict.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            private readonly Dictionary<string, object> _dict = new Dictionary<string, object>();
        }
    }
