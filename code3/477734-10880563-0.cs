    public interface ITest
	{
		void AwesomeInterface();
	}
    //As far as I could tell, this class is in some 3rd party DLL
	public class TheBaseClass
	{
		protected TheBaseClass(UserControl uc)
		{
			
		}
	}
    //Now this should work just fine
	public class ClassB<T> : TheBaseClass where T : UserControl, ITest
	{
		public ClassB(T param) : base(param)
		{
			param.AwesomeInterface();
		}
	}
