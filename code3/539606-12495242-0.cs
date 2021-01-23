	[Serializable()]
	public class Variable
	{
		int _shiftInt;
		public string shift
		{
			get
			{
				return _shiftInt.ToString("X");
			}
			set
			{
				_shiftInt = int.Parse(value, System.Globalization.NumberStyles.HexNumber);
			}
		}
		public int size { get; set; }
		public int min { get; set; }
		public int max { get; set; }
		public string name { get; set; }
		public string del { get; set; }
		public Variable()
		{
			_shiftInt = 26;
			size = 0;
			min = 0;
			max = 0;
			name = "noname";
			del = "-";
		}
	}
