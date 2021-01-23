	class BaseMapping<TEntity> : EntityTypeConfiguration<TEntity>
		where TEntity : Model.Base.BaseEntity
	{
		public BaseMapping()
		{
			//Some basic mapping logic which I want to implement to all my models 
		}
	}
	
