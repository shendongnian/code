     class ABC {  
		public ISomeInterface DoMagic<T>(Expression<Func<object>> action, Tuple<string, DateTime, decimal> tuple)
		where T : ISomeInterface
		{
			Magician m = new Magician();
			return m.Magic<T>(() => action, tuple.Item3);
		}
	}
	interface ISomeInterface { }
	class Magician
	{
		public ISomeInterface Magic<T>(Func<object> a, decimal d) where T:class
		{
			throw new NotImplementedException();
		}
	}
