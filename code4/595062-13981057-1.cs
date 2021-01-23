    public class MemberConfig : EntityTypeConfiguration<Member>
    {
        internal MemberConfig()
        {
            this.HasKey(m => m.ID);
            this.HasRequired(m => m.Address)
                .WithRequiredDependent(a => a.ID)
                .HasForeignKey(m => m.AddressId);
        }
     }
