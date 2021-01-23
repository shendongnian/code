    public class Entity
    {
        public XElement ToXElement() { ... }
        
        protected static T FromXElement<T>(XElement x)
            where T : Entity
        {
            ...
        }
    }
    
    public class Category : Entity
    {
        public static Category : FromXElement(XElement x)
        {
            return FromXElement<Category>(x);
        }
    }
