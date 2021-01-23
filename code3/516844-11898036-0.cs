    class BaseEntity
    {
    
    }
    class MessageList : BaseEntity
    {
    
    }
    class Application:BaseEntity
    {
    	public List<BaseEntity> MessageLists { get; set; }
    	public Application()
    	{
    		MessageLists = new List<BaseEntity>();
    	}
    }
    class ExpressionHelper
    {
    	public static Action<object,object> GetMethod(string targetTypename,string targetMemberName,string sourceTypeName)
    	{
    		ParameterExpression targetExpression = Expression.Parameter(typeof(object));
    		MemberExpression propertyExpression = Expression.PropertyOrField(Expression.TypeAs(targetExpression, Type.GetType(targetTypename)), targetMemberName);
    		ParameterExpression sourceExpression = Expression.Parameter(typeof(object));
    		Expression callExpression = Expression.Call(propertyExpression, "Add", null, Expression.TypeAs(sourceExpression, Type.GetType(sourceTypeName)));
    		//Expression.Convert()
    		var lambda = Expression.Lambda<Action<object, object>>(callExpression, targetExpression, sourceExpression);
    		var method = lambda.Compile();
    		return method;
    	}
    }
