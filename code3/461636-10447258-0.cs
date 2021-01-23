    public static T ConvertByGenerics<T>(string input) {
    
        // be mindful of boxing 
        if (input is T) {
            return (T)(object)input;
        }
    
        if (input == null) {
            // throw arugment exception 
        }
    
        // can check for int, long ......
        if (typeof(T).IsEnum) {
            return (T)System.Enum.Parse(typeof(T), input, true);
        }
    
        if (typeof(T).IsAssignableFrom(typeof(string))) {
            return (T)(object)input;
        }
    
        try {
            return (T)Convert.ChangeType(input, typeof(T));
        }
        catch { //do nothing
        }
    
        // might want to cache some converters
        System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
        if (converter.CanConvertFrom(typeof(string))) {
            return (T)converter.ConvertFrom(input);
        }
        else {
            // better though to throw an exception here 
            return default(T);
        }
    }
