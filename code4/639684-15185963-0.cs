    public class Transaction 
    {
        [Key]
        public int TransactionId {get;set;}
        public string Username {get;set;}
        // Whatever the column is
        public int OccasionServiceId {get;set;}
        [ForeignKey("OccasionServiceId")] // What on Transaction points to Service's Key
        public Service OccasionService {get;set;}
    }
    
    public class Service 
    {  
        // Ideally this would be called ServiceId instead?
        [Key]
        public int TransactionId {get;set;}
        // If this uses TransactionId then are you sure you don't need a Key that is ServiceId
        public Transaction Transaction { get; set; }
        [ForeignKey("TransactionId")] // What on ServiceAddon points at Service's Key
        public virtual ICollection<ServiceAddon> ServiceAddons { get; set; }
    }
    
    public class ServiceAddon
    {
        [Key]
        public int ServiceAddonId { get; set; }
        public int TransactionId { get; set; }
        public int AddonId { get; set; }
        public decimal AddonPrice { get; set; }
        public virtual Addon Addon { get; set; }
    }
