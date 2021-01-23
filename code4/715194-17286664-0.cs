    class Person
    {
    	protected string _name;
       	public virtual string Name{
    		get{
    			return _name;
    		}
    	}
    }
    
    class EditablePerson:Person
    {
    	public new string Name{
    		get{
    			return _name;
    		}
    		set{
    			_name=value;
    		}
    	}
        public Person AsPerson()
        {
            //either return this (and simply constrain by interface)
            //or create an immutable copy
        }
    }
