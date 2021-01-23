    /// <summary>
    /// Extension methods showing samples of using the ExtensionDataAttribute class directly, for use 
    /// in situations where it is undesirable to include the extension methods provided with that class
    /// </summary>
    public static class ExtensionMethodsExample1 {
        
        /// <summary>
        /// Adds a description to the specified string object
        /// </summary>
        /// <param name="s">The string to describe</param>
        /// <param name="description">The description to set</param>
        public static void SetDescription(this string s, string description) {
            if (string.IsNullOrWhiteSpace(description))
                description = "";
            
            foreach (Attribute a in System.ComponentModel.TypeDescriptor.GetAttributes(s))
                if (a is ExtensionDataAttribute) {
                    ((ExtensionDataAttribute)a)["Description"] = description;
                    return;
                }
            
            ExtensionDataAttribute extensionData = new ExtensionDataAttribute();
            extensionData["Description"] = description;
            extensionData.AddTo(s);
        }
        
        /// <summary>
        /// Gets the description for the specified string, if it has one; 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string GetDescription(this string s) {
            foreach (Attribute a in System.ComponentModel.TypeDescriptor.GetAttributes(s))
                if (a is ExtensionDataAttribute) {
                    ExtensionDataAttribute eda = (ExtensionDataAttribute)a;
                    if (eda.ContainsKey("Description"))
                        return eda["Description"].ToString();
                    else
                        return "";
                }
            return "";
        }
    }
        
    /// <summary>
    /// Extension methods encapsulating calls to extension methods provided with the ExtensionDataAttribute 
    /// class, demonstrating increased ease of implementing one's own extension data
    /// </summary>
    public static class ExtensionMethodsExample2 {
        public static string GetDescription(this string s)
        {
            return s.GetExtensionDataAttributeValue<string>("Description");
        }
        
        public static void SetDescription(this string s, string description)
        {
            s.SetExtensionDataAttributeValue("Description", description);
        }
    }
