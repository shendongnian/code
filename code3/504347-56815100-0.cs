    public class Employee
    {
        public string Name { get; set; }
        public Employee Manager { get; set; }
    
        public bool ShouldSerializeManager()
        {
            // don't serialize the Manager property if an employee is their own manager
            return (Manager != this);
        }
    }
    
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public new static readonly ShouldSerializeContractResolver Instance = new ShouldSerializeContractResolver();
    
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
    
            if (property.DeclaringType == typeof(Employee) && property.PropertyName == "Manager")
            {
                property.ShouldSerialize =
                    instance =>
                    {
                        Employee e = (Employee)instance;
                        return e.Manager != e;
                    };
            }
    
            return property;
        }
    }
