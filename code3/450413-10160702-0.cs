    public class MyClass
    {
        private StringBuilder builder;
        private StringBuilder RouteBuilder
        {
            get
            {
                if (builder == null)
                    builder = new StringBuilder();
    
                return builder;
            }
        }
    
        public MyClass Root()
        {
            RouteBuilder.Append("/");
            return this;
        }
    
        public MyClass And()
        {
            RouteBuilder.Append("and");
            return this;
        }
    
        public MyClass Something()
        {
            RouteBuilder.Append("something");
            return this;
        }
    }
