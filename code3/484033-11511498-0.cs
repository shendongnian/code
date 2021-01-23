    public class DemoClass
    {
        public delegate string MyDelegate(string testValue);
        public static MyDelegate DefaultBehavior
        {
            get
            {
                return testValue => 
                  { 
                     return String.Concat(testValue, 
                                          ", now with 99% more exclamation points!!!!!!!!"); 
                  };
            }
        }
        public MyDelegate ModifyString = testValue => 
            { 
               return DemoClass.DefaultBehavior(testValue); 
            };
    }
