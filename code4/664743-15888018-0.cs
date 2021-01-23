	IQueryable FixupExpressionTree( ObjectContext ctx, Type entityType, Expression expression )
	{
		var tObjectContext = ctx.GetType();
		var mCreateObjectSetOpen = tObjectContext.GetMethod( "CreateObjectSet", new Type[ 0 ] );
		var mCreateObjectSetClosed = mCreateObjectSetOpen.MakeGenericMethod( entityType );
		
		var objectQuery = ( ObjectQuery ) mCreateObjectSetClosed.Invoke( ctx, null );
		
		var eFixed = new Visitor( objectQuery, entityType ).Visit( expression );
		
		var qFixed = ( ( IQueryable ) objectQuery ).Provider.CreateQuery( eFixed );
		
		return qFixed;
	}
