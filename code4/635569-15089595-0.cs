    [Table("Ticket_Admins")]
    public class TicketAdmin
    {
        public TicketAdmin()
        {
            Name = new Record();
            Name.IsRevisioned = false;
            Name.IsVisible = true;
            Name.Category = typeof(TicketAdmin).Name;
        }
        [Key]
        public int Id { get; set; }
        public virtual Record Name { get; set; }
        public virtual TicketPost Post { get; set; }
        [ForeignKey("UserId")]
        public virtual UserProfile User { get; set; }
    }
