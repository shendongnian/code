    //instead of the lightweight interface (but use interface if it makes more sense)
	abstract class LwBase 
	abstract class HwBase : LwBase
	public interface IADiff { int APropTrick { get; } }
	// lightweight class definitions
	class LwA : LwBase, IADiff
	class LwB : LwBase
	// full class definitions
	class FullA : HwBase, IADiff
	class FullB : HwBase
	public static class AExtensions
	{
		public static void MyFunction(this IADiff o)
		{
			// impl.
		}
	}
