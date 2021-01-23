    public interface A
    {
    	void Initialise();
    	A DeepCopy();
    }
    
    public abstract class A<TType, TContentType> : A where TType : A
    {
    	public abstract void Initialise();
    	public abstract TType DeepCopy();
    	A A.DeepCopy() { return this.DeepCopy(); }
    	public TContentType Value { get; protected set; }
    }
    
    public class B : A<B, double>
    {
    	public override void Initialise() { this.Value = 3.0; }
    	public override B DeepCopy() { return new B(); }
    }
    
    public class C : A<C, char>
    {
    	public override void Initialise() { this.Value = 'v'; }
    	public override C DeepCopy() { return new C(); }
    }
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		List<A> listBC = CreateList();
    		List<A> list = CreateList(new B(), 3);
    	}
    
    	public static List<A> CreateList()
    	{
    		List<A> myList = new List<A>();
    		myList.Add(new B());
    		myList.Add(new C());
    		return myList;
    	}
    
    	public static List<A> CreateList(A baseA, int length)
    	{
    		List<A> myList = new List<A>(length);
    		
    		for (int i = 0; i < length; i++)
    		{
    			A copy = baseA.DeepCopy();
    			copy.Initialise();
    			myList.Add(copy);
    		}
    		return myList;
    	}
    }
