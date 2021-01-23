    public interface IVisitor<in T> where T : IVisitable<T>
    {
        void Visit(T visitable);
    }
    public interface IVisitable<T> where T : IVisitable<T>
    {
        void Accept(IVisitor<T> visitor);
    }
    public abstract class Visitable<T> : IVisitable<T> where T : Visitable<T>
    {
        public void Accept(IVisitor<T> visitor)
        {
            visitor.Visit((T)this);
        }
    }
    public abstract class VisitableList<T> : List<T>, IVisitable<T> where T : IVisitable<T>
    {
        public void Accept(IVisitor<T> visitor)
        {
            foreach (var item in this)
            {
                item.Accept(visitor);
            }
        }
    }
