        [DataContract(Name = "Products")]
        public class ProductDTO
        {
            [Key]
            [DataMember]
            public string MyProductMember1 { get; set; }
    
            [DataMember]
            public string MyProductMember2 { get; set; }
            ...
        }
