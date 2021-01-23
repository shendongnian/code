    public interface IValidable
    {
        void Validate();
    }
    // Sample class without nested fields, requiring validation.
    public class A2 : IValidable
    {
        public void Validate()
        {
            Console.WriteLine("Validated: " + ToString());
        }
    }
    // Sample nested class with nested fields, requiring validation.
    public class A1 : IValidable
    {
        private A2 a21 = new A2();
        private A2 a22 = new A2();
        public void Validate()
        {
            Console.WriteLine("Validated: " + ToString());
        }
    }
    // Root class for validation.
    public class A : IValidable
    {
        private A1 a1 = new A1();
        private A2 a2 = new A2();
        public void Validate()
        {
            Console.WriteLine("Validated: " + ToString());
        }
        public void ValidateAll()
        {
            Validate();
            ValidateAll(this);
        }
        private void ValidateAll(object o)
        {
            foreach (FieldInfo fieldInfo in o.GetType().GetFields(BindingFlags.Instance |
                   BindingFlags.NonPublic |
                   BindingFlags.Public))
            {
                IValidable current = fieldInfo.GetValue(o) as IValidable;
                if(current != null)
                {
                    current.Validate();
                    ValidateAll(current);
                }
            }
        }
    }
