    public class Entity
    {
    }
    public class Entity<T> : Entity where T : Entity<T>, new()
    {
        public XElement ToXElement()
        {
        }
        public static T FromXElement(XElement x)
        {
        }
    }
