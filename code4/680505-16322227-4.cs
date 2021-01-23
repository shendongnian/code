    public abstract class Entity
    {
        private readonly EntityData data;
        protected Entity(Action<EntityData> initializeData)
        {
            this.data = initializeData(new EntityData());
        }
    }
    public class Employee : Entity
    {
        public Employee : base(SomeStaticAction)
        {
        }
    }
