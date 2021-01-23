    public abstract class EntityWithAddresses : BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
    public partial class Person : EntityWithAddresses 
    {
    }
    public partial class Company : EntityWithAddresses 
    {
    }
