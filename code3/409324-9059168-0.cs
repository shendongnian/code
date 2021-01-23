    var t1 = new Tag(1);
    var t2 = new Tag(1);
    Console.WriteLine(t1 == t1); // true
    Console.WriteLine(t1 == t2); // true
    Console.WriteLine(t1 == null); // false
    Console.WriteLine(t1 != null); // true
    public class Tag
	{
		private readonly int _mask;
		public Tag(int mask)
		{
			_mask = mask;
		}
		public bool Equals(Tag other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return other._mask == _mask;
		}
		public override int GetHashCode()
		{
			return _mask;
		}
		
		public static bool operator !=(Tag x, Tag y)
		{
			return !x.Equals(y);
		}
		
		public static bool operator ==(Tag x, Tag y)
		{
			return x.Equals(y);
		}
	}
