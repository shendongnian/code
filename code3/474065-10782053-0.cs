    public class Base
    {
        public virtual bool Action()
        {
           ..
           return boolean-value.
        }
    }
    
    public class Child : Base
    {
        public override bool Action()
        {
           if(!base.Action()) 
             return false;
    
           ....
           return boolean-value;
        }
    }
