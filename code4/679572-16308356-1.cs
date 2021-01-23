    class A{public virtual void CallMe(string incString){Console.WriteLine(incString);}}
    class B : A
    {
     public override void CallMe(string incString)
     {
        incString += "_new";
        Console.WriteLine(incString);
     }
	
     public T CallMe<T>(string incString)
     {
		CallMe(incString);
		object o;
		switch( typeof(T).ToString() ){
			case "System.String":
				o = incString;
				break;
			case "System.Int32":
				o = 1;
				break;
			default:
				o = Activator.CreateInstance<T>();
				break;
		}
		return (T)o;
     }
    }
