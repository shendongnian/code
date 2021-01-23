    class Info
    {
    	public string X1 { set; get; }
    	public string X2 { set; get; }
    	public int X3 { set; get; }
    	private Action<Info, List<object>> initAction;
    
    	public void Init(Dictionary<string, object> initDict)
    	{
    		//on first usage we deal with reflection and build expression tree to init properties
    		if (initAction==null)
    		{
    			ParameterExpression targetInstanceExpression = Expression.Parameter(this.GetType());
    			ParameterExpression valuesExpression = Expression.Parameter(typeof(List<object>));
    			ParameterExpression value = Expression.Variable(typeof(object));
    			ParameterExpression enumerator = Expression.Variable(typeof(IEnumerator));
    			
    			var expList = new List<Expression>();
    			expList.Add(Expression.Assign(enumerator, Expression.TypeAs(Expression.Call(valuesExpression, "GetEnumerator", null),typeof(IEnumerator))));
    			foreach (var initRecord in initDict)
    			{
    				Expression moveNextExp = Expression.Call(enumerator, "MoveNext", null);
    				expList.Add(moveNextExp);
    				Type type = initRecord.Value.GetType();
    				expList.Add(Expression.Assign(value, Expression.PropertyOrField(enumerator, "Current")));
    				Expression assignExp = GetPropAssigner(initRecord.Key, type, targetInstanceExpression, value);
    				expList.Add(assignExp);
    			}
    			Expression block = Expression.Block
    			(
    				 new[] { value, enumerator },
    				 expList
    			);
    			//compile epression tree and get init action 
    			initAction = Expression.Lambda<Action<Info, List<object>>>(block, targetInstanceExpression, valuesExpression).Compile();
    		}
    		initAction(this, initDict.Values.ToList());
    	}
    	//little method to create property assigner
    	public static Expression GetPropAssigner(string propName, Type type,
    		 ParameterExpression targetInstanceExp, ParameterExpression valueExp)
    	{
    		MemberExpression fieldExp = Expression.PropertyOrField(targetInstanceExp, propName);
    		BinaryExpression assignExp = Expression.Assign(fieldExp, type.IsValueType ? Expression.Unbox(valueExp, type) : Expression.TypeAs(valueExp, type));
    		return assignExp;
    	}
    }
