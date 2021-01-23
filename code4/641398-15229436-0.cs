    using System;
    
    namespace InterceptSetter
    {
        interface ISomeObject
        {
            string SomeProperty { get; set; }
            void Filter();
        }
    
        public class SomeObject : ISomeObject
        {
            public string SomeProperty { get; set; }
    
            public void Filter()
            {
                Console.Out.WriteLine("Filter Called");
            }
        }
    }
