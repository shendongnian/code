	public class MyClass
	{
		private ITimer _timer;
		public ITimer Timer
		{
			get { return _timer; }
			set 
			{
				if(_timer = null && value != null)
				{
					value.Interval = 5000;
				}
				_timer = value;
			}
	}
