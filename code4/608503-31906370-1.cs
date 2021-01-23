	class Model
	{
		public readonly int Id;
		public string Data;
		public Model(int id, string data)
		{
			Id = id;
			Data = data;
		}
		public override int GetHashCode()
		{
			return Id;
		}
		protected bool Equals(Model other)
		{
			return Id == other.Id;
		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((Model) obj);
		}
	}
