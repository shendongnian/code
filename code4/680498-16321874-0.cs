        protected Entity(Type type)
        {
            _initActions[type].Invoke(_data);
        }
    }
    
    public class Employee : Entity
    {
        static Type mytype = typeof(Employee);
        public string Name { get; set; }
        public Employee(): base(mytype)
        { }
    }
