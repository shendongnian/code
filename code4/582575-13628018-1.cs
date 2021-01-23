	public class Ctx{
		public readonly Object _lock = new Object();
		private int v1 = 0;
		public int V1{
			get{
				lock(_lock)
					return v1;
			}
			set{
				lock(_lock)
					v1 = value;
			}
		}
	}
