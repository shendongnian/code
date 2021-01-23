	public class Visitor : ExpressionVisitor
	{
		ObjectQuery _Source = null;
		Type _EntityType = null;
		
		public Visitor( ObjectQuery source, Type entityType ) { _Source = source; _EntityType = entityType; }
		
		protected override Expression VisitConstant( ConstantExpression node )
		{
			if ( !node.Type.Name.Contains( "EnumerableQuery" ) ) return base.VisitConstant( node );
			
			var eConstantInstance = Expression.Constant( _Source );
			var eConstantArgument = Expression.Constant( MergeOption.AppendOnly );
			
			var tObjectQueryOpen = typeof( ObjectQuery<> );
			var tObjectQueryClosed = tObjectQueryOpen.MakeGenericType( _EntityType );
			var eMergeAsMethod = tObjectQueryClosed.GetMethod( "MergeAs", BindingFlags.Instance | BindingFlags.NonPublic );
			
			return Expression.Call( eConstantInstance, eMergeAsMethod, eConstantArgument );
		}
	}
