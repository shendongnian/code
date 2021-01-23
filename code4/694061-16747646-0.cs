    public class DonationMap : EntityTypeConfiguration<Donation>{
        public DonationMap() {
            // Primary Key
            HasKey(t => t.Id);
            
            // Properties
            Property(t => t.Id).IsRequired();
            Property(t => t.FirstName).HasMaxLength(200).IsRequired();
            Property(t => t.LastName).HasMaxLength(200).IsRequired();
            Property(t => t.DonationAmount).HasColumnType("Money").IsRequired();
            // Column Mappings
            // PaymentTransaction is a navigation property
            //HasRequired(m => m.PaymentTransaction); // gives me column name "PaymentTransaction_PaymentTransactionId"
            HasRequired(m => m.PaymentTransaction).WithMany().Map(m => m.MapKey("PaymentTransactionId"));
            // Table Mapping
            ToTable("Donation");
        }
    }
