    void Main()
    {
    	var orList = new List<A> {new A {Id = 0, S = "a"}, new A {Id = 1, S = "b"}, new A {Id = 2, S = "c"}, new A {Id = 4, S = "e"}};
    	var tmList = new List<A> {new A {Id = 2, S = "cc"}, new A {Id = 3, S = "dd"}};
	
    	var result = orList.Union(tmList, new AComparer()).ToList();
    	result.RemoveAll(a => tmList.All(at => at.Id != a.Id));
    }
    public class A {
    	public int Id;
    	public string S;
    }
    class AComparer : IEqualityComparer<A> {
    	public bool Equals(A x, A y) { return x.Id == y.Id; }
    	public int GetHashCode(A a)	{ return a.Id; }
    }
