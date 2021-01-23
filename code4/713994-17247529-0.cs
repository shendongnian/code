    public abstract class AbstractClass : IBaseClass
    {
        public AbstractClass(int handlerId)
        {
           this.HandlerId = handlerId;
        }
        public int  GetHandlerID()
        {
          return (this.HandlerID);
        }
    }
    
    public class MyClass : AbstractClass
    {
        public MyClass():base(1)//specific handler id
    }
