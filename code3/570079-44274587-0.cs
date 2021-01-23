    [Table("Staffs")]
    public class AccountUser
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual Account Account { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
