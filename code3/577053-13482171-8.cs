    public abstract class EntityBase
    {
        EntityBase()
        {
            DoStuffOnAdd();
        }
        protected virtual void DoStuffOnAdd() { }
    }
