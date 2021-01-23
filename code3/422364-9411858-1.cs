    public abstract class A
    {
        public virtual string GetName()
        {
            return null;
        }
    }
    public class B : A
    {
        //assume there are some defined properties.
        public new string GetName()
        {
            return FirstName;
        }
    }
