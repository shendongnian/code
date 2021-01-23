    public class TreeConfiguration : EntityTypeConfiguration<Tree>
    {
        public TreeConfiguration()
        {
            HasOptional(x => x.Parent)
                .WithMany(x => x.Children)
                .Map(m => m.MapKey("PARENT_ID"));
            HasMany(x => x.Children)
                .WithOptional(x => x.Parent);
            
            HasMany(x => x.Ancestors)
                .WithMany(x => x.Descendants)
                .Map(m => m.ToTable("Tree_Hierarchy").MapLeftKey("PARENT_ID").MapRightKey("CHILD_ID"));
            HasMany(x => x.Descendants)
                .WithMany(x => x.Ancestors)
                .Map(m => m.ToTable("Tree_Hierarchy").MapLeftKey("CHILD_ID").MapRightKey("PARENT_ID"));
        }    
    }
