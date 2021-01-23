    public class Memberships
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }
        //if you set your model up like this entity framework will take care of creating
        /the foreign key for you.
        public Application MemberApplication { get; set; }
    }
