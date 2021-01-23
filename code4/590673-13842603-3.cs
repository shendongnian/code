    public abstract class BaseDto
    {
        public abstract void ValidateObject();
    }
    // Sample class without nested fields, requiring validation.
    public class A2 : BaseDto
    {
        public override void ValidateObject()
        {
            Console.WriteLine("Validated: " + ToString());
        }
    }
    // Sample nested class with nested fields, requiring validation.
    public class A1 : BaseDto
    {
        private A2 Object1 = new A2();
        private A2 Object2 = new A2();
        private Stream stream = new MemoryStream();
        public override void ValidateObject()
        {
            Console.WriteLine("Validated: " + ToString());
        }
    }
    public class A : BaseDto
    {
        private A1 Object1 = new A1();
        private A2 Object2 = new A2();
        // we do nothing with this field
        private Stream stream = new MemoryStream();
        private A1 Object3 = new A1();
        public override void ValidateObject()
        {
            Console.WriteLine("Validated: " + ToString());
        }
        public void ValidateAll()
        {
            ValidateObject();
            ValidateAll(this);
        }
        private void ValidateAll(object o)
        {
            foreach (FieldInfo fieldInfo in o.GetType().GetFields(BindingFlags.Instance |
                   BindingFlags.NonPublic |
                   BindingFlags.Public))
            {
                BaseDto current = fieldInfo.GetValue(o) as BaseDto;
                if(current != null)
                {
                    current.ValidateObject();
                    ValidateAll(current);
                }
            }
        }
    }
