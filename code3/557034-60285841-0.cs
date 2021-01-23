csharp
void Main()
{
	Fixture fixture = new Fixture();
	
	fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true, Relay = new QueryableBuilder() });
	// Possible ways to "override" the AutoMoqBehavior
//	fixture.Inject<string>("hallO");
//	fixture.Inject(new[] { "asd" });
//	fixture.Inject(new[] { "asds" }.AsQueryable());
	var queryable = fixture.Create<Foo>();
	queryable.Bar();
	fixture.Create<IQueryable<string>>().Any(x => x.Equals("asd"));
}
public class QueryableBuilder : ISpecimenBuilder
{
	MockRelay _Base = new MockRelay();
	
	public object Create(object request, ISpecimenContext context)
	{
		var t = request as Type;
		if (t == null ||
			!t.IsGenericType ||
			t.GetGenericTypeDefinition() != typeof(IQueryable<>))
			return _Base.Create(request, context);
		var queryableTypeName = typeof(IQueryable<>).Name;
		if (t.Name != queryableTypeName)
			return _Base.Create(request, context);
		var entityType = t.GetGenericArguments().Single();
		
		var tt = entityType.MakeArrayType();
		dynamic blbb = context.Resolve(tt);
		return ((IEnumerable)blbb).AsQueryable();
	}
}
public interface IHaveQueryable {
	IQueryable<string> Queryable {get;}
}
public class Foo {
	
	readonly IHaveQueryable _Queryable;
	
	public Foo(IHaveQueryable queryable){
		_Queryable = queryable;
	}
	
	public bool Bar(){
		return _Queryable.Queryable.Any(x => x.Equals("bar"));
	}
}
