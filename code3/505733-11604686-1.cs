	public abstract class BasePt3
	{
		protected int x;
	}
	
	public class LocationPt3 : BasePt3
	{
		public int X
		{
			get { return x; }
			set { x = value; }
		}
		public LocationPt3(int _x)
		{
			x = _x;
		}
	}
	
	public class NormalPt3 : BasePt3
	{
		public int X
		{
			get { return x; }
		}
		public NormalPt3(int _x)
		{
			x = _x;
		}
	}
