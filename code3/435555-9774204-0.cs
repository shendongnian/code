    void foo (string[] temp)
    {
    	temp[0] = "Boom";
    }
    -------------
    string[] temp = new [] {"one", "two", "three"};
    foo(temp);
    foreach (string s in temp)
    	System.Console.WriteLine(s);
