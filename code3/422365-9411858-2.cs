    public abstract class A
    {
        public abstract string GetName()
    }
    // to override
    public class B : A
    {
        //assume there are some defined properties.
        public override string GetName()
        {
            return FirstName;
        }
    }
