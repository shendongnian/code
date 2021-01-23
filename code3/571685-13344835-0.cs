    // This example takes 3 parameters...
    public class GenericConstraint<T1, T2, T3>
    {
        public GenericConstraint(Type type)
        {
            if (!(type is T1) || !(type is T2) || !(type is T3))
            {
                throw new Exception("This is not a supported type");
            }
        }
    }
