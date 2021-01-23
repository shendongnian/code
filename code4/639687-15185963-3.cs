    public class Transaction 
    {
        [Key]
        public int TransactionId {get;set;}
        public string Username {get;set;}
        public int ServiceId {get;set;}
        [ForeignKey("ServiceId")]
        public Service Service {get;set;}
    }
    
    public class Service 
    {  
        [Key]
        public int ServiceId {get;set;}
        public int TransactionId {get;set;}
        [ForeignKey("TransactionId")
        public Transaction Transaction { get; set; }
        [ForeignKey("TransactionId")] // What on ServiceAddon points at Service's Key
        public virtual ICollection<ServiceAddon> ServiceAddons { get; set; }
    }
    
    public class ServiceAddon
    {
        [Key]
        public int ServiceAddonId { get; set; }
        public int ServiceId {get;set;}
        [ForeignKey("ServiceId")]
        public Service Service {get;set;}
    }
