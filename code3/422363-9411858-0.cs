    public abstract class A
    {
        public abstract string GetName();
    }
    public class B : A
    {
        //assume there are some defined properties.
        public new string GetName()
        {
            return FirstName;
        }
    }
