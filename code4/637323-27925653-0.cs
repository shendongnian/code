    public class SubscriptionMap: EntityTypeConfiguration<Subscription>
    {
        // Primary Key
        HasKey(p => p.Id)
        Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        Property(p => p.SubscriptionNumber).IsOptional().HasMaxLength(20);
        ...
        ...
        Ignore(p => p.SubscriberSignature);
        ToTable("Subscriptions");
    }
