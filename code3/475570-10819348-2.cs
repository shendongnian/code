    [DataContract] 
    [KnownType(typeof(Dog))] 
    public class Animal : IExtensibleDataObject 
    {
        public virtual string name; 
     
        ExtensionDataObject IExtensibleDataObject.ExtensionData { get; set; } 
    } 
     
    [DataContract] 
    public class Dog : Animal 
    { 
        [DataMember] 
        public override string name; 
 
        [DataMember] 
        public int age; 
    } 
