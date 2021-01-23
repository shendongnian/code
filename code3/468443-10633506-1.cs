	public class YourEqualityComparer: IEqualityComparer<ThisClass>
	{
		#region IEqualityComparer<ThisClass> Members
		
		public bool Equals(ThisClass x, ThisClass y)
		{
			//no null check here, you might want to do that, or correct that to compare just one part of your object
			return x.a == y.a && x.b == y.b;
		}
		
		public int GetHashCode(ThisClass obj)
		{
			unchecked
			{
				var hash = 17;
                                //same here, if you only want to get a hashcode on a, remove the line with b
				hash = hash * 23 + obj.a.GetHashCode();
				hash = hash * 23 + obj.b.GetHashCode();
				return hash;	
			}
		}
		#endregion
	}
