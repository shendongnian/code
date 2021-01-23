	class RangeMap<T>
		{
		public RangeMap()
			{
			_values = new SortedList<float, T>();
			}
		public void  AddPoint(float max, T value)
			{
			_values[max] = value;
			}
		public T  GetValue(float point)
			{
			if (_values.ContainsKey(point))  return _values[point];
			return (from kvp in _values where kvp.Key > point select kvp.Value).FirstOrDefault();
			}
		private SortedList<float, T>  _values;
		}
		
		var  map = new RangeMap<Color>();
		map.AddPoint(0.0F, Color.Red);
		map.AddPoint(0.5F, Color.Green);
		map.AddPoint(1.0F, Color.Blue);
		
		Console.WriteLine(map.GetValue(-0.25F).Name);
		Console.WriteLine(map.GetValue( 0.25F).Name);
		Console.WriteLine(map.GetValue( 0.75F).Name);
		Console.WriteLine(map.GetValue( 1.25F).Name);
