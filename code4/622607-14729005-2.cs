    public abstract class E
    {
        public abstract void AbstractMethod(int i);
  
        public virtual void VirtualMethod(int i)
        {
            // Default implementation which can be overridden by subclasses.
        }
    }
    public class D : E
    {
        public override void AbstractMethod(int i)
        {
            // You HAVE to override this method
        }
        public override void VirtualMethod(int i)
        {
            // You are allowed to override this method.
        }
    }
