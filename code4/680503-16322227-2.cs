    public abstract class Entity
    {
        private readonly EntityData data = InitializeData(new EntityData());
        protected abstract void InitializeData(EntityData data);
    }
