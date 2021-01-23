class Foobar
{
    private int _size;
    public string Description 
    { 
        get 
        {    
            if (_size == 1)
            {
                return "Cute";
            }
            else if (_size &lt; 4)
            {
                return "Interesting";
            }
            else if (_size &lt; 10)
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
