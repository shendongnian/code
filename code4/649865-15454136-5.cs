    using System;
    
    namespace WindowsFormsApplication1
    {
        [Serializable]
        public class ChildClass
        {
            public int childProp1 { get; set; }
            public string childProp2 { get; set; }
            public double childProp3 { get; set; }
            public float childProp4 { get; set; }
            public bool childProp5 { get; set; }
            public ChildClass childProp6 { get; set; }
        }
    }
