    void Main()
    {    
    	Orange a = new Orange();
    	Apple b = new Apple();
    	string c = "Doh.";
    	
    	System.Console.WriteLine(MyFunc<dynamic, string>(a,b,c));
    }
    
    public static T2 MyFunc<T1, T2>( T1 a, T1 b, T2 c) where T2 : class
    {
        return (a.ToString() + b.ToString() + c.ToString()) as T2;
    }     
