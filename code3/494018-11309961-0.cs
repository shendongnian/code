	private int _a;
	public int A
	{
		get { return _a; }
		private set { 
			
			if (value < 0 || value > 10)
			{
				throw new ArgumentOutOfRangeException("A");
			}
		
			_a = value; 
		}
	}
