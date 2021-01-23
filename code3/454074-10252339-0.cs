    public class BaseEngine { }
    [XmlInclude(typeof(InternalCombustionEngine))]
    [XmlInclude(typeof(ElectricEngine))]
    public class Car
    {      
        public BaseEngine Engine { get; set; }
    }
