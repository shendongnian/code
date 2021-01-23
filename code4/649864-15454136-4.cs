    using System;
    
    namespace WindowsFormsApplication1
    {
        [Serializable]
        public class myClass
        {
            public int prop1 { get; set; }
            public string prop2 { get; set; }
            public double prop3 { get;private set; }
            public float prop4 { get; set; }
            public bool prop5 { get; set; }
            public ChildClass prop6 { get; set; }
    
            public myClass()
            {
                prop5 = false;
            }
    
            public myClass(int val1, string val2, double val3, float val4)
            {
                prop1 = val1;
                prop2 = val2;
                prop3 = val3;
                prop4 = val4;
                prop5 = true;
            }
        }
    }
