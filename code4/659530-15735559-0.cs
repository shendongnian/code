    public class Service
    {
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int serviceId { get; set; }
    public int ServiceCategoryId{get;set;}
    public string name { get; set; }
    public string description { get; set; }
    public ServiceCategory ServiceCategory { get; set; }
    }
