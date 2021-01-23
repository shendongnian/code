    You will have to add EmitDefaultValue on you field
    
     [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, EmitDefaultValue=false)]
        public bool Is_ActiveNull {
    
    and then 
    
    [OnDeserializing]
        void BeforeDeserialization(StreamingContext ctx)
        {
            this.Is_ActiveNull = false;
        }
