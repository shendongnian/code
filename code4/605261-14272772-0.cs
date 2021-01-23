    var d1 = new Derived1(); // OK
    var d2 = new Derived2(); // throw error at run-time
    
    public class Base
    {
        public Base()
        {
            CheckCustomAttribute();
            
        }
        private void CheckCustomAttribute()
        {
            if (!(this.GetType() == typeof(Base))) // Ingore Base for attribute
            {
                //  var attr = System.Attribute.GetCustomAttributes(this.GetType()).SingleOrDefault(t=>t.GetType() == typeof(CustomAttribute));
                var attr = System.Attribute.GetCustomAttributes(this.GetType()).SingleOrDefault(t => typeof(CustomAttribute).IsAssignableFrom(t.GetType())); // to include derived type of Custom attribute also
                if (attr == null)
                {
                    throw new Exception(String.Format("Derived class {0} doesnot apply {1} attribute", this.GetType().Name, typeof(CustomAttribute).Name));
                }
            }
        }
    }
    [CustomAttribute]
    class Derived1 : Base
    {
    }
    class Derived2 : Base
    {
    }
    class CustomAttribute : System.Attribute
    {
    }
