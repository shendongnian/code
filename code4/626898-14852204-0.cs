    [DataContract(Name = "Product")]
    public class ProductDTO
    {
        [DataMember(Name = "ProductId")]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        // Other properties
    }
