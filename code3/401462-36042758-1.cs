    public class MyClass
	{	
        public MyClass()
        {	
            _list = new List<string>();
	    }
	    private IList<string> _list;
	    public IList<string> MyList 
        { 
            get
            { 
                return _list;
            }
        }
    }
    //In some other method
    var sample = new MyClass
    {
        MyList = {"a", "b"}
    };
