	public interface O { }
	public interface I : O { }
	public abstract class A : O { }
	public class C : A, I { }
	public class Program {
		static void Update(List<O> l, A a, I i, C c) {
			l.Add(a);
			l.Add(i);
			l.Add(c);
		}
	}
