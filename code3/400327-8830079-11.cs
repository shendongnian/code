    interface IElement { void Accept(IVisitor visitor); }
    
    class Alpha : IElement 
    {
        public virtual void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    } 
    class Beta : Alpha 
    {
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
    // etc.  
