    public abstract class Shape
    {
         public bool isMovable()
         {
             return false;
         }
         public virtual void Move()
         { 
             if (!isMovable() {
                 throw new NotSupportedException();
             } else {
                 throw new BadSubclassException();
             }
         }
    }
