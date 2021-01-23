    public abstract class EntityBase : INotifyPropertyChanged
    {
        EntityBase()
        {
            DoStuffOnAdd();
        }
        protected virtual void DoStuffOnAdd() { }
    }
