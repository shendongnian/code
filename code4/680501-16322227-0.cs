    public abstract class Entity
    {
        private readonly data = InitializeData(new EntityData());
        protected abstract void InitializeData(EntityData data);
    }
