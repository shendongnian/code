    public static class XAttributeExtensions
    {
        public static XAttribute SetAttribute(this XElement self, string name, object value)
        {
            // test for correct arguments
            if (null == self)
                throw new ArgumentNullException("XElement to SetAttribute method cannot be null!");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Attribute name cannot be null or empty to SetAttribute method!");
            if (null == value) // how to handle?
                value = ""; // or can throw an exception like one of the above.
            // Now to the good stuff
            XAttribute a = self.Attribute(name);
            if (null == a)
                self.Add(a = new XAttribute(name, value));
            else
                a.Value = value.ToString();
            return a;
        }
    }
