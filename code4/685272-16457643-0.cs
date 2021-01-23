    public class A : IEquatable<Service>
    {
        public virtual int Id { get; set; }
        public virtual string AccountName { get; set; }
        public virtual string AccountId { get; set; }
        public virtual Status Status { get; set; }
        public virtual IList<Service> Services { get; set; }
    }
    var commonListofService = services1.Intersect(services2);
