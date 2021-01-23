	public ParentMap()
	{
		this.HasKey(t => t.Id);
		this.HasRequired(p => p.Category).WithMany().HasForeignKey(p => p.CatCode);
		...
	}
	public CategoryMap()
	{
		this.HasKey(t => t.CatCode);
		this.ToTable("CategoryEx");
		...
	}
