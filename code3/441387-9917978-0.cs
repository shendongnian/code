	public abstract class Problem<P, C>
		where P : Problem<P, C>
		where C : Configuration<P, C>
		{ }
		
	public abstract class Configuration<P, C>
		where P : Problem<P, C>
		where C : Configuration<P, C>
		{ }
		
	public interface IProblemFactory<P, C>
		where P : Problem<P, C>
		where C : Configuration<P, C>
	{
		P CreateProblem(C configuration);
	}
