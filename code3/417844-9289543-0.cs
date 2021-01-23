    public class PropertyCollection : List<Property>
    {
        public Property this[string name]
        {
            get
            {
                foreach (Property prop in this)
                {
                    if (prop.Name == name)
                        return prop;
                }
                return null;
            }
        }
    }
