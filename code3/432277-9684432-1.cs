    public class Category
    {
       public long Id { get; private set; }
       public string CategoryName { get; private set; }
       public long? ParentCategoryId { get; private set; }
       public virtual Category ParentCategory { get; private set; }       
       public virtual ICollection<Category> SubCategories { get; private set; }
    }
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            this.HasKey(x => x.Id);
            this.HasMany(category => category.SubCategories)
                .WithOptional(category => category.ParentCategoryId)
                .HasForeignKey(course => course.UserId)
                .WillCascadeOnDelete(false);
        }
    }
