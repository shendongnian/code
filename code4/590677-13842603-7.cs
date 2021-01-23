    public abstract class BaseDto
    {
        public abstract bool ValidateObject();
    }
    // Sample class without nested fields, requiring validation.
    public class Case2 : BaseDto
    {
        public override bool ValidateObject()
        {
            Console.WriteLine("Validated: " + ToString());
            return false;
        }
    }
    // Sample nested class with nested fields, requiring validation.
    public class Case1 : BaseDto
    {
        private Case2 Object1 = new Case2();
        private Case2 Object2 = new Case2();
        private Stream stream = new MemoryStream();
        public override bool ValidateObject()
        {
            Console.WriteLine("Validated: " + ToString());
            return true;
        }
    }
    public class Case : BaseDto
    {
        private Case1 Object1 = new Case1();
        private Case2 Object2 = new Case2();
        // don't touch this field
        private Stream stream = new MemoryStream();
        private Case1 Object3 = new Case1();
        public override bool ValidateObject()
        {
            Console.WriteLine("Validated: " + ToString());
            return true;
        }
        public bool ValidateAll()
        {
            if (!ValidateObject()) return false;
            return ValidateAll(this);
        }
        private bool ValidateAll(object o)
        {
            foreach (FieldInfo fieldInfo in o.GetType().GetFields(BindingFlags.Instance |
                   BindingFlags.NonPublic |
                   BindingFlags.Public))
            {
                BaseDto current = fieldInfo.GetValue(o) as BaseDto;
                if(current != null)
                {
                    bool result = current.ValidateObject();
                    if(!result)
                    {
                        return false;
                    }
                    return ValidateAll(current);
                }
            }
            return true;
        }
    }
