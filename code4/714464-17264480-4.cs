    /// <summary>
    /// Extension methods for setting and getting extension data for individual objects, no matter the type
    /// </summary>
    public static class ExtensionDataAttributeExtensions {
            
        public static void SetExtensionDataAttributeValue(this object o, string name, object value)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name");
            try
            {
                foreach (Attribute a in System.ComponentModel.TypeDescriptor.GetAttributes(o))
                    if (a is ExtensionDataAttribute)
                    {
                        ((ExtensionDataAttribute)a)[name] = value;
                        return;
                    }
            }
            catch { }
        
            try
            {
                ExtensionDataAttribute extensionData = new ExtensionDataAttribute();
                extensionData[name] = value;
                extensionData.AddTo(o);
            }
            catch { }
        }
        
        public static T GetExtensionDataAttributeValue<T>(this object o, string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name");
            try
            {
                foreach (Attribute a in System.ComponentModel.TypeDescriptor.GetAttributes(o))
                    if (a is ExtensionDataAttribute)
                        return (T)((ExtensionDataAttribute)a)[name];
            }
            catch { }
            return default(T);
        }
        
        public static object GetExtensionDataAttributeValue(this object o, string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name");
            try
            {
                foreach (Attribute a in System.ComponentModel.TypeDescriptor.GetAttributes(o))
                    if (a is ExtensionDataAttribute)
                        return ((ExtensionDataAttribute)a)[name];
            }
            catch { }
            return null;
        }
        
        public static void RemoveExtensionDataAttributeValue(this object o, string name) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name");
            try
            {
                foreach (Attribute a in System.ComponentModel.TypeDescriptor.GetAttributes(o))
                    if (a is ExtensionDataAttribute)
                        ((ExtensionDataAttribute)a).Remove(name);
            }
            catch { }
        }
        
    }
