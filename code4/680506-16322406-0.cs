    public abstract class Entity
    {
        private static Dictionary<Type, Action<EntityData>> _initActions = 
                    new Dictionary<Type, Action<EntityData>>();
    
        protected abstract EntityData _data { get; }
    
        protected Entity()
        {
            _initActions[this.GetType()].Invoke(_data);
        }
    }
    
    public class Employee : Entity
    {
        public string Name { get; set; }
        protected overrides EntityData _data { 
             get { return new EntityData("Employee Stuff"); } 
        }
    }
    
    public class Manager : Employee
    {
        public List<Employee> Subordinates { get; set; }
        protected overrides EntityData _data { 
             get { return new EntityData("Manager Stuff"); } 
        }
    }
