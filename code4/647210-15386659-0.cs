	class Vector :  IEquatable<Vector>
	{
		/*Some fields and methods*/
			
		public bool Equals(Vector other)
		{
			if (ReferenceEquals(other, null)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Column.Equals(other.Column) && Row.Equals(other.Row) && TableID.Equals(other.TableID);
		}
		public override int GetHashCode()
		{
			return Column.GetHashCode() ^ Row.GetHashCode() ^ TableID.GetHashCode();
		}
	}
