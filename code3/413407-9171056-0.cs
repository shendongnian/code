    public class ChildResource : ParentResource
    {
        [DataMember(EmitDefaultValue = false, Order = 2)]
        public int ChildProperty1 { get; set; }
    
        [DataMember(EmitDefaultValue = false, Order = 3)]
        public int ChildProperty2 { get; set; } 
    }
