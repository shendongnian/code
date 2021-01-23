    public class Entity
    {
        public XElement ToXElement() { ... }
        
        public static T FromXElement<T>(XElement x)
            where T : Entity
        {
            ...
        }
    }
