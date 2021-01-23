    public class MyClass
    {
        public int PageLoadCounter = 0;
        public static MyClass Static
        {
            get
            {
                IObjectFactory factory = new HttpSessionObjectFactory();
                return factory.CreateOrReuse<MyClass>();
            }
        }
    }
