    internal sealed class MyEntityConfiguration : EntityTypeConfiguration<MyEntity>
    {
            public MyEntityConfiguration()
            {
                // this is a composite key configuration
                HasKey(_ => new { _.NodeId, _.ItemId });
    
                Property(_ => _.NodeId);
                Property(_ => _.ItemId);
                Property(_ => _.Name);
            }
    }
