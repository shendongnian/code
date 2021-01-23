	abstract class LwBase 
	abstract class HwBase : LwBase
	public interface IADiff { int MyFunction(); }
	public class AConcr : IADiff //implemenst Myfunction()
	// lightweight class definitions
	class LwA : LwBase, IADiff
	{
		private AConcr a = new AConcr();
		public int MyFunction() { return a.MyFunction(); }
	}
	class LwB : LwBase
	// full class definitions
	class FullA : HwBase, IADiff
	{
		private AConcr a = new AConcr();
		public int MyFunction() { return a.MyFunction(); }
	}
	class FullB : HwBase
