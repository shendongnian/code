    public abstract class Shape : IMove 
    {
         public virtual void Move()
         { 
             throw new NotSupportedException();
         }
    }
