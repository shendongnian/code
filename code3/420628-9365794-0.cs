	public class ExtendedEntityTypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity>
	{
		public UniqueConstraintConfiguration<TEntity> HasUnique(string propertyName)
		{
			var result = new UniqueConstraintConfiguration<TEntity>();
			result.WithColumn(propertyName);
			return result;
		}
		public UniqueConstraintConfiguration<TEntity> HasUnique<TProperty>(Expression<Func<TEntity, TProperty>> property)
		{
			var result = new UniqueConstraintConfiguration<TEntity>();
			result.WithColumn(property);
			return result;
		}
	}
	public abstract class UniqueConstraintConfiguration
	{
		public UniqueConstraintConfiguration WithColumn(string propertyName)
		{
			// TODO: add code here
			return this;
		}
	}
	public class UniqueConstraintConfiguration<TEntity> : UniqueConstraintConfiguration
	{
		public new UniqueConstraintConfiguration<TEntity> WithColumn(string propertyName)
		{
			base.WithColumn(propertyName);
			return this;
		}
		public UniqueConstraintConfiguration<TEntity> WithColumn<TProperty>(Expression<Func<TEntity, TProperty>> property)
		{
			base.WithColumn(((MemberExpression)property.Body).Member.Name);
			return this;
		}
	}
