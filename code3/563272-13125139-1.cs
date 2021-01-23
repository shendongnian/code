    public class InvoicingAddressMap : EntityTypeConfiguration<InvoicingAddress>
    {
        public InvoicingAddressMap()
        {
            HasRequired(t => t.Post)
                .WithMany(t => t.InvoicingAddresses)
                .HasForeignKey(d => d.PostId);
        }
    }
