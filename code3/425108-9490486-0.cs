      class OuterClass
        {
            public _InnerClass InnerClass;
            public OuterClass()
            {
                InnerClass = new _InnerClass();
            }
    
            public int OuterNumber { get; set; }
    
            public class _InnerClass
            {
                public int InnerNumber { get; set; }
            }
    
            public _InnerClass InnerClass { get; set; }
    
        }
