    public class DynamicDictionary<T>:IDynamicMetaObjectProvider{
    	...
    	public T Get(Func<dynamic,dynamic> arg){
    			return arg(this);
    	}
    	
    	public void Set(Action<dynamic> arg){
    			arg(this);
    	}
    }
    ...
    var dictionary = new DynamicDictionary<FooClass>();
    dictionary.Set(d=>d.Foo = new FooClass());
    dictionary.Get(d=>d.Foo).SomeMethod(); 
