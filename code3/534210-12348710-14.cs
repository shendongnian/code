	Public Function GetPropName(Of TClass, TProperty)(exp As Expression(Of Func(Of TClass, TProperty))) as String
		Return DirectCast(exp.Body, MemberExpression).Member.Name
	End Function
    ...
 
    GetPropName(Function(x) x.Name)
