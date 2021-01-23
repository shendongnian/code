	public class Identity : IEquatable<Identity>
	{
		public Guid UniqueIdentifier { get; set; }
		public string Name { get; set; }
		public bool IsEmpty
		{
			get { return UniqueIdentifier == Guid.Empty; }
		}
		#region Construction
		public Identity()
		{
		}
		public Identity( Guid uniqueIdentifier, string name )
		{
			UniqueIdentifier = uniqueIdentifier;
			Name = name;
		} 
		#endregion
		public override string ToString()
		{
			return string.IsNullOrWhiteSpace( Name ) ? UniqueIdentifier.ToString() : Name;
		}
		#region IEquatable
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}
		public override bool Equals( object obj )
		{
			return Equals( obj as Identity );
		}
		public static bool operator ==( Identity left, Identity right )
		{
			if( ReferenceEquals( null, left ) )
				return ReferenceEquals( null, right );
			return left.Equals( right );
		}
		public static bool operator !=( Identity left, Identity right )
		{
			if( ReferenceEquals( null, left ) )
				return !ReferenceEquals( null, right );
			return !left.Equals( right );
		}
		public bool Equals( Identity other )
		{
			if( ReferenceEquals( null, other ) )
				return false;
			return ToString() == other.ToString();
		}
		#endregion
	}
