    Public class BaseType
    {
        public BaseType(object something)
        {
    
        }
    }
    public class MyType : BaseType
    {
         public MyType(object context) : base(context)
         {
         } 
    }
