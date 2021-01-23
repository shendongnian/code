    public sealed class Supercollider
    {    
        public static T Initialize<T>(object propertySource)
        {
            // you can provide overloads for types that don't have a default ctor
            var result = Activator.CreateInstance(typeof(T)); 
            foreach(var prop in ReflectionHelper.GetProperties(typeof(T)))
                ReflectionHelper.SetPropertyValue(
                    result, // the target
                    prop,  // the PropertyInfo 
                    propertySource); // where we get the value
        }    
    }
