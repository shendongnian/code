	public override int GetHashCode()
	{
		unchecked
		{
			int result = (Name != null ? Name.GetHashCode() : 0);
			result = (result*397) ^ (Street != null ? Street.GetHashCode() : 0);
			result = (result*397) ^ Age;
			return result;
		}
	}
