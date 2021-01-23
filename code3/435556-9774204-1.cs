    void foo (string[] temp) // create a copy of a reference to the string array
    {
    	temp[0] = "Boom"; // temp still points to the same object
    }
    -------------
    string[] temp = new [] {"one", "two", "three"}; //outer variable
    foo(temp); // behind the scene we have two variables pointing to the same array
    foreach (string s in temp)
    	System.Console.WriteLine(s);
