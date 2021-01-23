    public class A : IEquatable<A>
    {
        public virtual int Id { get; set; }
        public virtual string AccountName { get; set; }
        public virtual string AccountId { get; set; }
        public virtual Status Status { get; set; }
        public virtual IList<Service> Services { get; set; }
    
        //Implement IEquatable interfaces 
        //...
    }
