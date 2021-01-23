    public static class Extensions
    {
        public static T ConvertTo<T>(this Dictionary<string, string> dictionary)
            where T : new()
        {
            dynamic target = new T();
            return (T)Extensions.FillFrom(target, dictionary);
        }
    
        private static object FillFrom(this object obj, 
                                       Dictionary<string, string> dictionary)
        {
            var message = "Conversion to " + obj.GetType() + " is not supported.";
            throw new NotSupportedException(message);
        }
    
        private static TargetA FillFrom(this TargetA target, 
                                        Dictionary<string, string> dictionary)
        {
            // throw exception if required keys not found
            target.Foo = dictionary["foo"];
            return target;
        }
    
        private static TargetB FillFrom(this TargetB target, 
                                        Dictionary<string, string> dictionary)
        {
            // throw exception if required keys not found
            target.Bar = dictionary["bar"];
            return target;
        }
    }
