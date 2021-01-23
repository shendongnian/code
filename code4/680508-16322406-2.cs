    public abstract class Entity
    {
        private static Dictionary<Type, Action<EntityData>> _initActions = 
                    new Dictionary<Type, Action<EntityData>>();
    
        private void InitalizeBase() { /* do shared construction */ }
        protected abstract void Initalize();
           
        protected Entity()
        {
            InitalizeBase();
            Initalize();
        }
    }
    public class Employee : Entity
    {
        public string Name { get; set; }
        protected overrides Initalize()
        {
            // Do child stuff
        }
    }
