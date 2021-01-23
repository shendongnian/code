    public abstract class BaseDto
    {
        public abstract void ValidateObject();
    }
    // Sample class without nested fields, requiring validation.
    public class Case2 : BaseDto
    {
        public override void ValidateObject()
        {
            Console.WriteLine("Validated: " + ToString());
        }
    }
    // Sample nested class with nested fields, requiring validation.
    public class Case1 : BaseDto
    {
        private Case2 Object1 = new Case2();
        private Case2 Object2 = new Case2();
        private Stream stream = new MemoryStream();
        public override void ValidateObject()
        {
            Console.WriteLine("Validated: " + ToString());
        }
    }
    public class Case : BaseDto
    {
        private Case1 Object1 = new Case1();
        private Case2 Object2 = new Case2();
        // we do nothing with this field
        private Stream stream = new MemoryStream();
        private Case1 Object3 = new Case1();
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
