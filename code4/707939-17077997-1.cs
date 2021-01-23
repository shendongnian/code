    class Class1
        {
            public int Get()
            {
                return 1;
            }
            public Class1()
            {
                
            }
    
            public virtual void ForBoth()
            {
    
            }
        }
    
        class class2 : Class1
        {
            public class2()
            {
                
            }
    
            public override void ForBoth()
            {
                base.ForBoth();
            }
    
            public int Get()
            {
                return 2;
            }
    
        }
