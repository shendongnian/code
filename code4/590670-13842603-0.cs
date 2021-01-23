    public interface IValidable
    {
        void Validate();
    }
    public class A2 : IValidable
    {
        public void Validate()
        {
            Console.WriteLine("Validated: " + ToString());
        }
    }
    public class A1 : IValidable
    {
        private A2 a21 = new A2();
        private A2 a22 = new A2();
        public void Validate()
        {
            Console.WriteLine("Validated: " + ToString());
        }
    }
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
            foreach (FieldInfo fieldInfo in o.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
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
