     public class MyApiKeyMapping : EntityTypeConfiguration<MyApiKey>
     {
         public MyApiKeyMapping()
         {
             this.ToTable("MyApiKey");
             this.HasKey(k => k.KeyId);
             this.Property(p => p.vCode).IsRequired();
         }
    }
    public class AccountEntryMapping : EntityTypeConfiguration<AccountEntry>
    {
        public AccountEntryMapping()
        {
            this.ToTable("AccountEntry");
            this.HasKey(k => k.CharacterId);
        }
    }
