    [DataContract(Name="Item", Namespace = "http://matchingnamespace")] 
        public class Item 
        { 
            [DataMember(Name="Param1")] 
            public string param1{ get; set; } 
     
            [DataMember(Name="Param2")] 
            public string param2{ get; set; } 
        } 
