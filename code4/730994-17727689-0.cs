    public partial class AccountGroup
    {
        public long AccountGroupID { get; set; }
        public string Name { get; set; }
        public virtual User User { get; set; }
    }
