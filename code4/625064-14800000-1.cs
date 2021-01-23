    public abstract class NamedLifeForm : LifeForm
    { 
        public string Name { get; set; }
    }
    public class Person : NamedLifeForm
    {
        // Person inherits both a Name and all relevant members of LifeForm
    }
