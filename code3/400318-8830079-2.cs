    interface IElement
    {
        void Accept(IVisitor visitor);
    }
    // showing one implementation, also implement elsewhere 
    class Epsilon : Beta, IElement 
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    } 
