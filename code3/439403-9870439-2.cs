     public class HandlerAttribute : System.Attribute
    {
        public string MainName { get; private set; }
        public string SubName { get; private set; }
        public HandlerAttribute(string pValue, bool pIsMain)
        {
            if (pIsMain) MainName = pValue;
            else SubName = pValue;
        }
    }
    [Handler("SomeMainName", true)]
    class Class1
    {
        [Handler("SomeSubName", false)]
        public void HandleThis()
        {
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(this.GetType());  // reflection
            foreach (System.Attribute attr in attrs)
            {
                if (attr is HandlerAttribute)
                {
                    string mainName = (attr as HandlerAttribute).MainName;
                }
            }
        }
    }
