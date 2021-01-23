    public static class ObjectSetExtensions
    {
    	#region Constants
    
    	private const BindingFlags KeyPropertyBindingFlags =
    		BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
    
    	#endregion
    
    	#region Public Methods and Operators
    
    		public static bool RecordExists<TEntity>(
    		this ObjectSet<TEntity> set, 
    		TEntity entity) where TEntity : class
    	{
    		Contract.Requires(set != null);
    		Contract.Requires(entity != null);
    
    		var expressionParameter = Expression.Parameter(typeof(TEntity));
    		var keyProperties = set.GetKeyProperties();
    
    		var matchExpression =
    			keyProperties.Select(
    				pi =>
    				Expression.Equal(
    					Expression.Property(expressionParameter, pi.Last()),
    					Expression.Constant(pi.Last().GetValue(entity, null))))
    				.Aggregate<BinaryExpression, Expression>(
    					null,
    					(current, predicate) => (current == null) ? predicate : 
    						Expression.AndAlso(current, predicate));
    
    		var existing =
    			set.SingleOrDefault(Expression.Lambda<Func<TEntity, bool>>(
    			matchExpression, 
    			new[] { expressionParameter }));
    
    		return existing != null;
    	}
    
    	#endregion
    
    	#region Methods
    
    	private static IEnumerable<PropertyPathCollection> GetKeyProperties<TEntity>(this ObjectSet<TEntity> objectSet)
    		where TEntity : class
    	{
    		Contract.Requires(objectSet != null);
    
    		var entityType = typeof(TEntity);
    
    		return
    			objectSet.EntitySet.ElementType.KeyMembers.Select(
    				c => new PropertyPathCollection(entityType.GetProperty(c.Name, KeyPropertyBindingFlags)));
    	}
    
    	#endregion
    }
    
    public sealed class PropertyPathCollection : IEnumerable<PropertyInfo>
    {
    	// Fields
    	#region Static Fields
    
    	public static readonly PropertyPathCollection Empty = new PropertyPathCollection();
    
    	#endregion
    
    	#region Fields
    
    	private readonly List<PropertyInfo> components;
    
    	#endregion
    
    	// Methods
    	#region Constructors and Destructors
    
    	public PropertyPathCollection(IEnumerable<PropertyInfo> components)
    	{
    		this.components = new List<PropertyInfo>();
    		this.components.AddRange(components);
    	}
    
    	public PropertyPathCollection(PropertyInfo component)
    	{
    		this.components = new List<PropertyInfo> { component };
    	}
    
    	private PropertyPathCollection()
    	{
    		this.components = new List<PropertyInfo>();
    	}
    
    	#endregion
    
    	#region Public Properties
    
    	public int Count
    	{
    		get
    		{
    			return this.components.Count;
    		}
    	}
    
    	#endregion
    
    	#region Public Indexers
    
    	public PropertyInfo this[int index]
    	{
    		get
    		{
    			return this.components[index];
    		}
    	}
    
    	#endregion
    
    	#region Public Methods and Operators
    
    	public static bool Equals(PropertyPathCollection other)
    	{
    		if (ReferenceEquals(null, other))
    		{
    			return false;
    		}
    
    		return true;
    	}
    
    	public static bool operator ==(PropertyPathCollection left, PropertyPathCollection right)
    	{
    		return Equals(left, right);
    	}
    
    	public static bool operator !=(PropertyPathCollection left, PropertyPathCollection right)
    	{
    		return !Equals(left, right);
    	}
    
    	public override bool Equals(object obj)
    	{
    		if (ReferenceEquals(null, obj))
    		{
    			return false;
    		}
    
    		if (ReferenceEquals(this, obj))
    		{
    			return true;
    		}
    
    		if (obj.GetType() != typeof(PropertyPathCollection))
    		{
    			return false;
    		}
    
    		return Equals((PropertyPathCollection)obj);
    	}
    
    	public override int GetHashCode()
    	{
    		return this.components.Aggregate(0, (t, n) => (t + n.GetHashCode()));
    	}
    
    	#endregion
    
    	#region Explicit Interface Methods
    
    	IEnumerator<PropertyInfo> IEnumerable<PropertyInfo>.GetEnumerator()
    	{
    		return this.components.GetEnumerator();
    	}
    
    	IEnumerator IEnumerable.GetEnumerator()
    	{
    		return this.components.GetEnumerator();
    	}
    
    	#endregion
    }
