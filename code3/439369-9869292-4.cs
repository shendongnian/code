    public abstract class ABase
    {
        protected const object DefaultParam1 = null;
        protected const object DefaultParam2 = null;
    
        public object Param1 {get;set;}
        public object Param2 { get; set; }
        protected object Param3 { get; set; }
    
        public ABase(object param1 = DefaultParam1, object param2 = DefaultParam2)
        {
            Param1 = param1;
            Param2 = param2;
        }
    }
    
    public class A : ABase
    {
        public A(object param1 = DefaultParam1, object param2 = DefaultParam2)
            : base(param1, param2)
        {
            Param3 = "param3";
        }       
    }
