        public class ABase
            {
                public object Param1 { get; set; }
                public object Param2 { get; set; }
                protected object Param3 { get; set; }
        
                public ABase()
                    : this(null, null)
                { }
        
                public ABase(object param1)
                    : this(param1, null)
                { }
        
                public ABase(object param1, object param2)
                {
                    Param1 = param1;
                    Param2 = param2;
                }
            }
        
            public class A : ABase
            {
                public A() : this(null, null)
                { }
        
                public A(object param1)
                    : this(param1m, null)
                { }
        
                public A(object param1, object param2)
                    : base(param1, param2)
                { InitParam3(); }
        
                private void InitParam3()
                {
                    Param3 = "param3";
                }
            }
    
