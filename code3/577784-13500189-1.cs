class Foobar
{
	private int _size;
    public string Description 
    { 
		get 
		{
			if (_size &lt;= 3)
			{
				switch (_size)
				{
					case 1:
						return "Cute";
						break;
					default: 
						return "Interesting";
						break;
				}                
			}
			else if (_size &gt; 4 && _size &lt; 10)
			{
				return "I'm sweating!";
			}
			else
			{
				return "I'm outta here - every man for himself";
			}
		}
	}
    
	public bool Scary 
	{ 
		get
		{
			return _size &gt; 3;
		}
	}
	
	public Foobar(int size) 
	{
	    _size = size;
	}
}
