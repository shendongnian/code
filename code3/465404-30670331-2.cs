	public class CustomDbContext : DbContext
	{
		ObjectContext _objectContext;
		public CustomDbContext( string nameOrConnectionString )
			: base( nameOrConnectionString )
		{
			var adapter = (( IObjectContextAdapter) this);
			_objectContext = adapter.ObjectContext;
			if ( _objectContext == null )
			{
				throw new Exception( "ObjectContext is null." );	
			}
			_objectContext.CommandTimeout = Settings.Default.DefaultCommandTimeoutSeconds;
		}
		public int? CommandTimeout
		{
			get
			{
				return _objectContext.CommandTimeout;
			}
			set
			{
				_objectContext.CommandTimeout = value;
			}
		}
	}
	
