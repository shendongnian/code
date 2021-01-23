    interface IVisitor
    {
       void DoBehavior(B item);
       void DoBehavior(C item);
    }
    abstract class A
    {
        abstract void DoBehavior(IVisitor visitor);
    }
    
    class B : A
    {
        override void DoBehavior(IVisitor visitor)
        {
           //can do some internal behavior here    
           visitor.DoBehavior(this); //external processing
        }
    }
    
    class C : A
    {
        override void DoBehavior(IVisitor visitor)
        {
           //can do some internal behavior here   
           visitor.DoBehavior(this); //external processing
        }
    }
    
    
    class Manager: IVisitor //(or executor or whatever. The external processing class)
    {
    
        public static void ProcessAll(List<A> items)
        {
            foreach(A item in items)
            {
                item.DoBehavior(this);
            }
        }
       void DoBehavior(B item)
       {
       }
       void DoBehavior(C item);
       { 
       }
    
    }
