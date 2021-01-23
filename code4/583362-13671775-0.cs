    private EntityRef<Category> _categoryRef = new EntityRef<Category>();
	[Association(ThisKey = "CatId", OtherKey = "CategoryId", IsForeignKey = true, DeleteOnNull = true, Storage = "_categoryRef")]
	public Category Category
	{
		get { return _categoryRef.Entity; }
		set
		{
			if (_categoryRef.Entity != value || !_categoryRef.HasLoadedOrAssignedValue)
			{
				_categoryRef.Entity = value;
			}
		}
	}
