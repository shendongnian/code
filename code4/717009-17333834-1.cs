	var param = System.Linq.Expressions.Expression.Parameter(typeof(TPocoText));
	var init = System.Linq.Expressions.Expression.MemberInit(
		System.Linq.Expressions.Expression.New(typeof(Foo)),
		new []{
			System.Linq.Expressions.Expression.Bind(GetMemberInfo((Foo f) => f.Nav), System.Linq.Expressions.Expression.PropertyOrField(param, "NameOfPropertyToBindToNav")),
			System.Linq.Expressions.Expression.Bind(GetMemberInfo((Foo f) => f.M1), System.Linq.Expressions.Expression.PropertyOrField(param, "M1")),
		}
	);
    var result = Context.Set<TPocoText>().Where((Expression<Func<TPocoText, bool>>) whereLambda)
                     .OrderByDescending(t => t.RowVersion).Skip(skip).Take(take)
                     .Select(System.Linq.Expressions.Expression.Lambda<Func<TPocoText, Foo>>(init, param));
    public class Foo
    {
        public string Nav {get;set;}
        public string M1 {get;set;}
    }
	public static MemberInfo GetMemberInfo<T, U>(Expression<Func<T, U>> expression)
	{
		var member = expression.Body as MemberExpression;
		if (member != null)
			return member.Member;
	
		throw new ArgumentException("Expression is not a member access", "expression");
	}
