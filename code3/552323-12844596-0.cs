        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
	    public class PropertyAttribute : System.Attribute
	    {
           public PropertyType Type { get; private set; }
           public PropertyAttribute (PropertyType type) { Type = type; }
        }
        public enum PropertyType
        {
           Meta,
           Real,
           Raw,
        }
