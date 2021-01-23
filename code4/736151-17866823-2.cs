    public class Mana : IComparable<Mana>
		{
			private readonly string _value;
			public Mana(string value)
			{
				_value = value;				
			}
			
			public int CompareTo(Mana other)
			{
				if (Value == "X")
					return 1;
				if (other.Value == "X")
					return -1;
				return Convert.ToInt32(Value).CompareTo(Convert.ToInt32(other.Value));
			}
		}
